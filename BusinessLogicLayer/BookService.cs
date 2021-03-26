using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }

    public interface IBookService
    {
        void CreateNewBook(BookDTO newBook);
        IEnumerable<BookDTO> GetAllBooks();
    }

    public class BookService : IBookService
    {
        private IUnitOfWork repositroties;
        private IMapper mapper;

        public BookService()
        {
            repositroties = new UnitOfWork();

            IConfigurationProvider config = new MapperConfiguration(
                cfg =>
                {
                    // From Entity to DTO
                    cfg.CreateMap<Book, BookDTO>()
                        .ForMember(dst => dst.GenreName, opt => opt.MapFrom(src => src.Genre.Name));
                    cfg.CreateMap<Author, AuthorDTO>();

                    // From DTO to Entity
                    cfg.CreateMap<BookDTO, Book>();
                    cfg.CreateMap<AuthorDTO, Author>();
                });

            mapper = new Mapper(config);
        }

        // Service Public Interface
        public void CreateNewBook(BookDTO newBook)
        {
            repositroties.BookRepos.Insert(mapper.Map<Book>(newBook));
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
    }
}
