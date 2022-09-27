using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class House
    {
        [Key]
        public int? HouseId { get; set; }

        public float HouseSize { get; set; }

        public float Price { get; set; }

        public string Address { get; set; }
        public string HouseStatus { get; set; }
        public string HouseType { get; set; }

        public int HouseFloorNo { get; set; }



    }
}
