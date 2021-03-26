namespace BusinessLogicLayer
{
    // Data Transfer Object (DTO) old name POCO
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }

        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public int AuthorId { get; set; }
        public AuthorDTO Author { get; set; }
    }
}
