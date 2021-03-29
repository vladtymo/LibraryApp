using System;
using System.Runtime.Serialization;

namespace WcfService
{
    [DataContract]
    public class AuthorDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public DateTime? BirthDate { get; set; }
    }
}
