using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pay.Admin.Bll;
using Pay.Admin.Dto;
using Pay.Admin.Model;
using Pay.Base.Common;
using Pay.Base.Common.Enums;
using Pay.Base.WebCore.ControllerExtensions;
using Pay.Dal;

namespace Pay.Admin.Service.Controllers
{
    public class AccountController : Controller
    {
        private AccountBll AccountBll { get; }

        public AccountController(PaySystemContext dbContext)
        {
            this.AccountBll = new AccountBll(dbContext);
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "管理登陆";
            return View();
        }
        
        public async Task<IActionResult> CreateAdmin(AddAdminViewModel model)
        {
            var result = new ResponseModel { ResultCode = (int)ResultCode.UnknownError };
            if (string.IsNullOrWhiteSpace(model.UserName))
            {
                result.ResultCode = (int)AccountResultCode.UserNameNotNull;
                result.Message = "用户名不能为空";
                return Json(result);
            }
            if (model.UserName.Length > 20)
            {
                result.ResultCode = (int)AccountResultCode.UserNameOutLength;
                result.Message = "用户名不能超过20个字符串";
                return Json(result);
            }
            if (string.IsNullOrWhiteSpace(model.Password))
            {
                result.ResultCode = (int)AccountResultCode.PasswordNotNull;
                result.Message = "密码不能为空";
                return Json(result);
            }
            if (model.Password.Length < 8)
            {
                result.ResultCode = (int)AccountResultCode.PasswordTooShort;
                result.Message = "密码不能小于8位";
                return Json(result);
            }
            if (model.Password.Length > 32)
            {
                result.ResultCode = (int)AccountResultCode.PasswordOutLength;
                result.Message = "密码不超过32位";
                return Json(result);
            }
            result = await this.AccountBll.AddAdminAccount(new AddAdminDto
            {
                Model = model,
                Result = result
            });
            return Json(result);
        }

        public IActionResult Login()
        {
            ViewData["Title"] = "管理";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel model)
        {
            var result = new ResponseModel { ResultCode = (int)ResultCode.UnknownError };
            if (string.IsNullOrWhiteSpace(model.UserName))
            {
                result.ResultCode = (int)AccountResultCode.UserNameNotNull;
                result.Message = "用户名不能为空";
                return Json(result);
            }
            if (string.IsNullOrWhiteSpace(model.Password))
            {
                result.ResultCode = (int)AccountResultCode.PasswordNotNull;
                result.Message = "密码不能为空";
                return Json(result);
            }
            result = await this.AccountBll.AdminLogin(new AdminLoginDto
            {
                Model = model,
                LoginIP = this.HttpContext.GetUserIp(),
                Result = result,
            });

            //登陆成功后写Session
            if (result.ResultCode == (int)ResultCode.Successful)
            {

            }

            return Json(result);
        }
    }
}