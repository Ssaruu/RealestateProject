using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class User
    {
        [Key]
        public int? SalesPersonId { get; set; }

        public string SalesPersonName { get; set; }
    }
}
