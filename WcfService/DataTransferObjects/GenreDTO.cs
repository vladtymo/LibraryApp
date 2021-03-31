using System.Runtime.Serialization;

namespace WcfService
{
    [DataContract]
    public class GenreDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
