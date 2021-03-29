using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IBookService
    {
        void CreateNewBook(BookDTO newBook);
        IEnumerable<BookDTO> GetAllBooks();
        IEnumerable<AuthorDTO> GetAllAuthors();
        IEnumerable<GenreDTO> GetAllGenres();
    }

    public class BookService : IBookService
    {
        private IUnitOfWork repositroties;
        private IMapper mapper;

        public BookService()
        {
            repositroties = new UnitOfWork();

            IConfigurationProvider config = new MapperConfiguration(cfg =>
                {
                    // From Entity to DTO
                    cfg.CreateMap<Book, BookDTO>();
                    cfg.CreateMap<Author, AuthorDTO>();
                    cfg.CreateMap<Genre, GenreDTO>();

                    // From DTO to Entity
                    cfg.CreateMap<BookDTO, Book>();
                    cfg.CreateMap<AuthorDTO, Author>();
                    cfg.CreateMap<GenreDTO, Genre>();
                });

            mapper = new Mapper(config);
        }

        // Service Public Interface
        public void CreateNewBook(BookDTO newBook)
        {
            repositroties.BookRepos.Insert(mapper.Map<Book>(newBook));
            repositroties.Save();
        }

        public IEnumerable<AuthorDTO> GetAllAuthors()
        {
            return mapper.Map<IEnumerable<AuthorDTO>>(repositroties.AuthorRepos.Get());
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {   
            var books = repositroties.BookRepos.Get();
            return mapper.Map<IEnumerable<BookDTO>>(books);

            ////////////// manual converter
            //List<BookDTO> result = new List<BookDTO>();

            //foreach (var b in books)
            //{
            //    result.Add(new BookDTO()
            //    {
            //        Id = b.Id,
            //        Title = b.Title,
            //        Pages = b.Pages,
            //        AuthorId = b.AuthorId,
            //        GenreId = b.GenreId,
            //        GenreName = b.Genre.Name,
            //        Author = new AuthorDTO()
            //        {
            //            Id = b.Author.Id,
            //            FirstName = b.Author.FirstName,
            //            LastName = b.Author.LastName,
            //            BirthDate = b.Author.BirthDate,
            //        }
            //    });
            //}

            //return result;

            ////////////// convert using yield return
            //foreach (var b in books)
            //{
            //    yield return new BookDTO()
            //    {
            //        Id = b.Id,
            //        Title = b.Title,
            //        Pages = b.Pages,
            //        AuthorId = b.AuthorId,
            //        GenreId = b.GenreId,
            //        GenreName = b.Genre.Name,
            //        Author = new AuthorDTO()
            //        {
            //            Id = b.Author.Id,
            //            FirstName = b.Author.FirstName,
            //            LastName = b.Author.LastName,
            //            BirthDate = b.Author.BirthDate,
            //        }
            //    };
            //}
        }

        public IEnumerable<GenreDTO> GetAllGenres()
        {
            return mapper.Map<IEnumerable<GenreDTO>>(repositroties.GenreRepos.Get());
        }
    }
}
