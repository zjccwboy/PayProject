using Pay.Admin.Dto;
using Pay.Dal;
using Pay.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Pay.Base.Common.Enums;
using Pay.Base.Common.Enums.Utils;
using Pay.Base.Common;

namespace Pay.Admin.Bll
{
    public class AccountBll
    {
        private PaySystemContext DbContext { get; set; }

        public AccountBll(PaySystemContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public async Task<ResponseModel> AddAdminAccount(AddAdminDto dto)
        {
            if (await this.DbContext.TAccount.FindAsync(new { Name = dto.Model.UserName }) != null)
            {
                dto.Result.ResultCode = (int)AccountResultCode.UserNameExisted;
                dto.Result.Message = "该用户名存在";
                return dto.Result;
            }

            //插入TAccount
            var account = new TAccount
            {
                Name = dto.Model.UserName,
                Password = dto.Model.Password,
                Type = dto.Model.AccountType,
                Emai = dto.Model.Email,
            };
            account.SetCreator(1);
            account.SetUpdater(1);
            await this.DbContext.AddOneAsync(account);
            var amax = await this.GetAdminMaxJobNumber();
            var cmax = await this.GetCustomerMaxJobNumber();

            //插入TAdmin
            var admin = new TAdmin
            {
                AccountId = account.Id,
                JobNumber = JobNumberUtils.GetJobNumber(amax, cmax),
            };
            admin.SetCreator(1);
            admin.SetUpdater(1);
            await this.DbContext.AddOneAsync(admin);

            if (await this.DbContext.SaveChangesAsync() <= 0)
            {
                dto.Result.Message = "数据保存失败";
                return dto.Result;
            }
            dto.Result.ResultCode = (int)ResultCode.Successful;
            return dto.Result;
        }

        public async Task<ResponseModel> AdminLogin(AdminLoginDto dto)
        {
            if (!this.DbContext.TAccount.Where(a=>a.Name == dto.Model.UserName).Select(a=> new { a.Id}).Any())
            {
                dto.Result.ResultCode = (int)AccountResultCode.UserNotExist;
                dto.Result.Message = "用户不存在";
                return dto.Result;
            }

            //查询管理员账号信息
            var accounts = this.DbContext.TAccount.Where(a => a.Type == AccountType.Admin)
                .Where(a => a.Name == dto.Model.UserName)
                .Join(this.DbContext.TAdmin, m => m.Id, f => f.AccountId, (m, f) =>
                    new
                    {
                        m.Id,
                        m.Password,
                        m.Name,
                        m.Type,
                        f.JobNumber,
                    }
                );

            var account = await accounts.FirstOrDefaultAsync();
            if (!dto.Model.Password.Equals(account.Password))
            {
                dto.Result.ResultCode = (int)AccountResultCode.PasswordError;
                dto.Result.Message = "密码错误";
                return dto.Result;
            }

            //更新管理最后一次登陆IP与时间
            var admin = await this.DbContext.TAdmin.FindAsync(account.Id);
            admin.LastLoginIp = dto.LoginIP;
            admin.LastLoginTime = DateTime.UtcNow;
            admin.SetUpdater(admin.AccountId);
            this.DbContext.TAdmin.Update(admin);

            //写登陆日志
            var loginLog = new TAdminLoginLog
            {
                AccountId = admin.AccountId,
                LoginIp = dto.LoginIP,
            };
            loginLog.SetCreator(admin.AccountId);
            loginLog.SetUpdater(admin.AccountId);
            await this.DbContext.AddOneAsync(loginLog);

            if (await this.DbContext.SaveChangesAsync() <= 0)
                return dto.Result;

            dto.Model.UserId = account.Id;
            dto.Result.ResultCode = (int)ResultCode.Successful;
            return dto.Result;
        }

        public async Task<int> GetAdminMaxJobNumber()
        {
            var q = this.DbContext.TAdmin.Where(a => a != null).Select(a => a.JobNumber);
            var list = await q.ToListAsync();
            if (list.Any())
                return list.Max();

            return 0;
        }

        public async Task<int> GetCustomerMaxJobNumber()
        {
            var q = this.DbContext.TCustomer.Where(a => a != null).Select(a => a.JobNumber);
            var list = await q.ToListAsync();
            if (list.Any())
                return list.Max();

            return 0;
        }
    }
}
