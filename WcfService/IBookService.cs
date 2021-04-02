using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    [ServiceContract(CallbackContract = typeof(ICallback))]
    public interface IBookService
    {
        [OperationContract(IsOneWay = true)]
        void CreateNewBook(BookDTO newBook);
        [OperationContract]
        IEnumerable<BookDTO> GetAllBooks();
        [OperationContract]
        IEnumerable<AuthorDTO> GetAllAuthors();
        [OperationContract]
        IEnumerable<GenreDTO> GetAllGenres();

        [OperationContract(IsOneWay = true)]
        void Login();
        [OperationContract(IsOneWay = true)]
        void Logout();
    }

    public interface ICallback
    {
        [OperationContract(IsOneWay = true)]
        void TakeBook(BookDTO book);
    }
}
