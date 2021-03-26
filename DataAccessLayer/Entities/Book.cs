using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
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
}