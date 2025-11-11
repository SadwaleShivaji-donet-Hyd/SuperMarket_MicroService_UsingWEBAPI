using System.ComponentModel.DataAnnotations;

namespace OrderMS.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId {  get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalAmount { get; set; }


    }
}
