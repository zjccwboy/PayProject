using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pay.Entities;

namespace Pay.Dal
{
    public partial class PaySystemContext : DbContext
    {
        public PaySystemContext()
        {
        }

        public PaySystemContext(DbContextOptions<PaySystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAccount> TAccount { get; set; }
        public virtual DbSet<TAdmin> TAdmin { get; set; }
        public virtual DbSet<TAdminLoginLog> TAdminLoginLog { get; set; }
        public virtual DbSet<TAdminOperationLog> TAdminOperationLog { get; set; }
        public virtual DbSet<TChannelGroup> TChannelGroup { get; set; }
        public virtual DbSet<TCustomer> TCustomer { get; set; }
        public virtual DbSet<TCustomerLoginLog> TCustomerLoginLog { get; set; }
        public virtual DbSet<TDfFailureOrder> TDfFailureOrder { get; set; }
        public virtual DbSet<TDfOrder> TDfOrder { get; set; }
        public virtual DbSet<TDfSetting> TDfSetting { get; set; }
        public virtual DbSet<TDfSuccessOrder> TDfSuccessOrder { get; set; }
        public virtual DbSet<TFailureOrder> TFailureOrder { get; set; }
        public virtual DbSet<TMerchant> TMerchant { get; set; }
        public virtual DbSet<TMerchantChannel> TMerchantChannel { get; set; }
        public virtual DbSet<TMerchantExtend> TMerchantExtend { get; set; }
        public virtual DbSet<TNotifyTicket> TNotifyTicket { get; set; }
        public virtual DbSet<TOrder> TOrder { get; set; }
        public virtual DbSet<TPaySetting> TPaySetting { get; set; }
        public virtual DbSet<TPercentage> TPercentage { get; set; }
        public virtual DbSet<TRefundOrder> TRefundOrder { get; set; }
        public virtual DbSet<TSuccessOrder> TSuccessOrder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAccount>(entity =>
            {
                entity.ToTable("T_Account");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Emai)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TAdmin>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("T_Admin");

                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FirstLoginIp)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.FirstLoginTime).HasColumnType("datetime");

                entity.Property(e => e.LastLoginIp)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoginTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TAdminLoginLog>(entity =>
            {
                entity.ToTable("T_AdminLoginLog");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.LoginIp)
                    .HasColumnName("LoginIP")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TAdminOperationLog>(entity =>
            {
                entity.ToTable("T_AdminOperationLog");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.LogContent)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TChannelGroup>(entity =>
            {
                entity.ToTable("T_ChannelGroup");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Channels)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TCustomer>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("T_Customer");

                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FirstLoginIp)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstLoginTime).HasColumnType("datetime");

                entity.Property(e => e.FullName).HasMaxLength(10);

                entity.Property(e => e.LastLoginIp)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoginTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TCustomerLoginLog>(entity =>
            {
                entity.ToTable("T_CustomerLoginLog");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.LoginIp)
                    .HasColumnName("LoginIP")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TDfFailureOrder>(entity =>
            {
                entity.HasKey(e => e.OrderNum);

                entity.ToTable("T_DfFailureOrder");

                entity.Property(e => e.OrderNum).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ChannelCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FromIp)
                    .HasColumnName("FromIP")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mid).HasColumnName("MId");

                entity.Property(e => e.Mnum)
                    .IsRequired()
                    .HasColumnName("MNum")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TDfOrder>(entity =>
            {
                entity.HasKey(e => e.OrderNum);

                entity.ToTable("T_DfOrder");

                entity.Property(e => e.OrderNum).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ChannelCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FromIp)
                    .HasColumnName("FromIP")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mid).HasColumnName("MId");

                entity.Property(e => e.Mnum)
                    .IsRequired()
                    .HasColumnName("MNum")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.NotifyUrl)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TDfSetting>(entity =>
            {
                entity.ToTable("T_DfSetting");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Extened)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.LastInfo).IsUnicode(false);

                entity.Property(e => e.PrivateKey)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.PublicKey)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.RedirectUrl)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Sid)
                    .HasColumnName("SId")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TDfSuccessOrder>(entity =>
            {
                entity.HasKey(e => e.OderNum);

                entity.ToTable("T_DfSuccessOrder");

                entity.Property(e => e.OderNum).ValueGeneratedNever();

                entity.Property(e => e.AlipayId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ChannelCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FromIp)
                    .HasColumnName("FromIP")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FrozenTime).HasColumnType("datetime");

                entity.Property(e => e.Mid).HasColumnName("MId");

                entity.Property(e => e.Mnum)
                    .IsRequired()
                    .HasColumnName("MNum")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.NotifyUrl)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Percentage).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TFailureOrder>(entity =>
            {
                entity.HasKey(e => e.OrderNum);

                entity.ToTable("T_FailureOrder");

                entity.Property(e => e.OrderNum).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ChannelCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Fmid).HasColumnName("FMId");

                entity.Property(e => e.FromIp)
                    .HasColumnName("FromIP")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mnum)
                    .IsRequired()
                    .HasColumnName("MNum")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TMerchant>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("T_Merchant");

                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.Property(e => e.AmountTotal).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BankAddress)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.BankCard)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.BankName).HasMaxLength(20);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DfuserGroup).HasColumnName("DFUserGroup");

                entity.Property(e => e.PayeeName).HasMaxLength(20);

                entity.Property(e => e.RecvNotifyUrl)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Rsa2key)
                    .IsRequired()
                    .HasColumnName("RSA2Key")
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.WithdrawPwd)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TMerchantChannel>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("T_MerchantChannel");

                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.Property(e => e.ChannelGroups)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Channels)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TMerchantExtend>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("T_MerchantExtend");

                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(128);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FullName).HasMaxLength(20);

                entity.Property(e => e.GoogleSecretKey)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IdCard)
                    .HasColumnName("Id_Card")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoginIp)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoginTime).HasColumnType("datetime");

                entity.Property(e => e.Mid).HasColumnName("MId");

                entity.Property(e => e.Mname)
                    .IsRequired()
                    .HasColumnName("MName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Msn)
                    .HasColumnName("MSN")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Postcode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Qq)
                    .HasColumnName("QQ")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StieUrl)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.WithdrawPwd)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TNotifyTicket>(entity =>
            {
                entity.ToTable("T_NotifyTicket");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TOrder>(entity =>
            {
                entity.HasKey(e => e.OrderNum);

                entity.ToTable("T_Order");

                entity.Property(e => e.OrderNum).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ChannelCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FromIp)
                    .HasColumnName("FromIP")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mid).HasColumnName("MId");

                entity.Property(e => e.Mnum)
                    .IsRequired()
                    .HasColumnName("MNum")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.NotifyUrl)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TPaySetting>(entity =>
            {
                entity.ToTable("T_PaySetting");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Extened)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastInfo).IsUnicode(false);

                entity.Property(e => e.PrivateKey)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.PublicKey)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.RedirectUrl)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Sid)
                    .HasColumnName("SId")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TPercentage>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("T_Percentage");

                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Percentage).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TRefundOrder>(entity =>
            {
                entity.HasKey(e => e.OderNum);

                entity.ToTable("T_RefundOrder");

                entity.Property(e => e.OderNum).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Mid).HasColumnName("MId");

                entity.Property(e => e.Mnum)
                    .IsRequired()
                    .HasColumnName("MNum")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.RefundAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RefundCharge).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TSuccessOrder>(entity =>
            {
                entity.HasKey(e => e.OderNum);

                entity.ToTable("T_SuccessOrder");

                entity.Property(e => e.OderNum).ValueGeneratedNever();

                entity.Property(e => e.AlipayId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ChannelCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FromIp)
                    .HasColumnName("FromIP")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FrozenTime).HasColumnType("datetime");

                entity.Property(e => e.Mid).HasColumnName("MId");

                entity.Property(e => e.Mnum)
                    .IsRequired()
                    .HasColumnName("MNum")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.NotifyUrl)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Percentage).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RefundTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });
        }
    }
}
