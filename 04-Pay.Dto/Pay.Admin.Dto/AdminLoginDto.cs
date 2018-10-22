using Pay.Admin.Model;
using Pay.Base.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pay.Admin.Dto
{
    public class AdminLoginDto : BaseDTO<AdminLoginViewModel, ResponseModel>
    {
        public string LoginIP { get; set; }
    }
}
