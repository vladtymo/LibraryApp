using System.Runtime.Serialization;

namespace WcfService
{
    // Data Transfer Object (DTO) old name POCO
    [DataContract]
    public class BookDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public int Pages { get; set; }
        [DataMember]
        public int GenreId { get; set; }
        [DataMember]
        public GenreDTO Genre { get; set; }
        [DataMember]
        public int AuthorId { get; set; }
        [DataMember]
        public AuthorDTO Author { get; set; }
    }
}
