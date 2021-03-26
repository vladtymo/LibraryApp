using BusinessLoginLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLibrary
{
    // перелік типів команд
    public enum CommandType
    {
        GetAllBooks,
        CreateBook, 
    }

    // клас, який містить інформацію, яка передається від клієнта на сервер
    [Serializable]
    public class ClientCommand
    {
        public CommandType Type { get; set; }

        public ClientCommand(CommandType type)
        {
            this.Type = type;
        }
    }
    [Serializable]
    public class CreateBookCommand : ClientCommand
    {
        public BookDTO Book { get; set; }
        public CreateBookCommand(CommandType type, BookDTO book) : base(type)
        {
            this.Book = book;
        }
    }
}
