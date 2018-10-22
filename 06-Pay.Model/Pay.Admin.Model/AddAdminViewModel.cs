using Pay.Base.Common;
using Pay.Base.Common.Enums;

namespace Pay.Admin.Model
{
    public class AddAdminViewModel : RequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public AccountType AccountType { get; set; } = AccountType.Admin;
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string QQ { get; set; }
    }
}
