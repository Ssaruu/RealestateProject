using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.ViewModels
{
    public class LoginViewModel
    {
        public string userId { get; set; }
        public string userName { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
