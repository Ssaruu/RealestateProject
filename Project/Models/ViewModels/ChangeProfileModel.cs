using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.ViewModels
{
    public class ChangeProfileModel
    {
        [Required]
        public string userName { get; set; }
        [Required,DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [Required,DataType(DataType.Password)]
        public string NewPassword { get; set; }

    }
}
