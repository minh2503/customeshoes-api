using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.Models.Login
{
    public class App_LoginResponse
    {
        public string AccessToken { get; set; }
        public string Redirect { get; set; }
    }
}
