using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Project.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage=" First Name required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = " Last Name required")]
        public string LastName { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
