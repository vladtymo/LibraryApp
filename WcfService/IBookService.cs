using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    [ServiceContract]
    public interface IBookService
    {
        [OperationContract]
        void CreateNewBook(BookDTO newBook);
        [OperationContract]
        IEnumerable<BookDTO> GetAllBooks();
        [OperationContract]
        IEnumerable<AuthorDTO> GetAllAuthors();
        [OperationContract]
        IEnumerable<GenreDTO> GetAllGenres();
    }
}
