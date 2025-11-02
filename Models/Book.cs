using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace author_book.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }

        // Foreign key for Author
        public int AuthorId { get; set; }
        // Navigation property
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
    }
}