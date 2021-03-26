using BusinessLoginLayer;
using CommandLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IBookService bookService = new BookService();

            const int port = 8080;
            IPAddress address = IPAddress.Parse("127.0.0.1");

            TcpListener server = new TcpListener(address, port);

            // запускаємо сервер
            server.Start();

            while (true)
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();

                    // отримуємо об'єкт команди від клієнта
                    BinaryFormatter formatter = new BinaryFormatter();
                    var command = (ClientCommand)formatter.Deserialize(client.GetStream());

                    // обробляємо команду
                    switch (command.Type)
                    {
                        case CommandType.GetAllBooks:
                            List<BookDTO> books = bookService.GetAllBooks().ToList();
                            formatter.Serialize(client.GetStream(), books);
                            break;
                        case CommandType.CreateBook:
                            var cmd = (CreateBookCommand)command;
                            bookService.CreateNewBook(cmd.Book);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Unknown command");
                            break;
                    }

                    client.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // зупиняємо сервер
            server.Stop();
        }
    }
}
