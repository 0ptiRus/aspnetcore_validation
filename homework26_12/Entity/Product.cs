using System.ComponentModel.DataAnnotations;

namespace homework26_12.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Price is required!")]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be a positive number!")]
        public int Price { get; set; }

        public Product(int id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public Product()
        {
        }

        public override string ToString() => $"Product {Id} {Name} {Price}";
    }
}
