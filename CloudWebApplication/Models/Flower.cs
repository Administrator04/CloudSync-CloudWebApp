using System.ComponentModel.DataAnnotations;

namespace CloudWebApplication.Models
{
    public class Flower
    {
        [Key]
        public int flowerID { get; set; }
        public string ? flowerName { get; set; }
        public string ? flowerType { get; set; }
        public DateTime flowerProducedDate { get; set; }
        public decimal flowerPrice { get; set; }

    }
}
