using System.ComponentModel.DataAnnotations;

namespace OrderMS.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
    }
}
