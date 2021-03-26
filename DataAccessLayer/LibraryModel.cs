using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer
{
    public class LibraryModel : DbContext
    {
        public LibraryModel()
            : base("name=LibraryModel")
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
    }

    public class Book
    {
        public int Id { get; set; }
        [Required, MaxLength(250)]
        public string Title { get; set; }
        public int Pages { get; set; }

        // FOREIGN KEYS
        public int AuthorId { get; set; }
        public int GenreId { get; set; }

        // NAVIGATION PROPERTIES
        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        [Required, MaxLength(500)]
        public string FirstName { get; set; }
        [Required, MaxLength(500)]
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
    public class Genre
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}