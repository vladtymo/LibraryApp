using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class Author
    {
        public int Id { get; set; }
        [Required, MaxLength(500)]
        public string FirstName { get; set; }
        [Required, MaxLength(500)]
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        // NAVIGATION PROPERTIES
        public virtual ICollection<Book> Books { get; set; }
    }
}