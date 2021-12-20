using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using mvcdemo.Data;

namespace mvcdemo.Models
{
    public class loginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}