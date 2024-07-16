using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}
