using Pay.Base.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pay.Admin.Model
{
    public class AdminLoginViewModel : RequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string VerifyCode { get; set; }
    }
}
