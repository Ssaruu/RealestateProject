using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Transaction
    {

        [Key]
        public int TransactionId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string Date { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int Houseid { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public string Price { get; set; }

    }
}
