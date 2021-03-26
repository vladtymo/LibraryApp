using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class Genre
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }

        // NAVIGATION PROPERTIES
        public virtual ICollection<Book> Books { get; set; }
    }
}