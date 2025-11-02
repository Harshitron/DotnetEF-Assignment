using System.ComponentModel.DataAnnotations;

namespace author_book.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string? Bio { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}