using author_book;
using author_book.Models;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            context.Database.EnsureCreated();

            var author = new Author
            {
                Name = "J.K. Rowling",
                Bio = "British author, best known for the Harry Potter series",
                Books = new List<Book>()
            };

            var books = new List<Book>
            {
                new Book
                {
                    Title = "Harry Potter and the Philosopher's Stone",
                    Description = "The first book in the Harry Potter series",
                    Price = 19.99M,
                    PublishedDate = new DateTime(1997, 6, 26),
                    Author = author
                },
                new Book
                {
                    Title = "Harry Potter and the Chamber of Secrets",
                    Description = "The second book in the Harry Potter series",
                    Price = 21.99M,
                    PublishedDate = new DateTime(1998, 7, 2),
                    Author = author
                }
            };

            context.Authors.Add(author);
            context.Books.AddRange(books);
            context.SaveChanges();
            Console.WriteLine("Author and books added successfully!");

            Console.WriteLine("\nAll Books with Authors:");
            var allBooks = context.Books
                .OrderBy(b => b.Price)  // Sort by price
                .ToList();

            foreach (var book in allBooks)
            {
                Console.WriteLine($"Book: {book.Title}, Price: ${book.Price}, Author: {book.Author.Name}");
            }
            var bookToUpdate = context.Books.FirstOrDefault();
            if (bookToUpdate != null)
            {
                bookToUpdate.Price = 24.99M;
                context.SaveChanges();
                Console.WriteLine($"\nUpdated price of '{bookToUpdate.Title}' to ${bookToUpdate.Price}");
            }

            var bookToDelete = context.Books.OrderBy(b => b.BookId).LastOrDefault();
            if (bookToDelete != null)
            {
                context.Books.Remove(bookToDelete);
                context.SaveChanges();
                Console.WriteLine($"\nDeleted book: {bookToDelete.Title}");
            }

            Console.WriteLine("\nBooks over $20:");
            var expensiveBooks = context.Books
                .Where(b => b.Price > 20)
                .ToList();

            foreach (var book in expensiveBooks)
            {
                Console.WriteLine($"Title: {book.Title}, Price: ${book.Price}");
            }
        }
    }
}
