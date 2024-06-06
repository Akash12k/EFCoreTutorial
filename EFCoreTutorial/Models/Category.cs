using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTutorial.Models
{
    public class Category
    {
        public int Id { get; set; }
        //[Column("CategoryName")]
        public string? Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
