using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLoginLayer
{
    // Data Transfer Object (DTO) or old name POCO
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public GenreDTO Genre { get; set; }
        public AuthorDTO Author { get; set; }
    }
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public interface IBookService
    {
        void CreateNewBook(BookDTO newBook);
        IEnumerable<BookDTO> GetAllBooks();
        IEnumerable<GenreDTO> GetAllGenres();
        IEnumerable<AuthorDTO> GetAllAuthors();
    }

    public class BookService : IBookService
    {
        IUnitOfWork repositories;
        IMapper mapper;

        public BookService()
        {
            repositories = new UnitOfWork();

            IConfigurationProvider config = new MapperConfiguration(
                cfg =>
                {
                    // from Entity to DTO
                    cfg.CreateMap<Genre, GenreDTO>();
                    cfg.CreateMap<Author, AuthorDTO>();
                    cfg.CreateMap<Book, BookDTO>();

                    // from DTO to Entity
                    cfg.CreateMap<GenreDTO, Genre>();
                    cfg.CreateMap<AuthorDTO, Author>();
                    cfg.CreateMap<BookDTO, Book>();
                });

            mapper = new Mapper(config);
        }

        // Service Public Interface
        public void CreateNewBook(BookDTO newBook)
        {
            repositories.BookRepos.Insert(mapper.Map<Book>(newBook));
            repositories.Save();
        }

        public IEnumerable<AuthorDTO> GetAllAuthors()
        {
            return mapper.Map<IEnumerable<AuthorDTO>>(repositories.AuthorRepos.Get());
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            var result = repositories.BookRepos.Get();

            return mapper.Map<IEnumerable<BookDTO>>(result);

            /////////////////// manual converter
            //List<BookDTO> books = new List<BookDTO>();

            //foreach (var b in result)
            //{
            //    books.Add(new BookDTO()
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

            //return books;
        }

        public IEnumerable<GenreDTO> GetAllGenres()
        {
            return mapper.Map<IEnumerable<GenreDTO>>(repositories.GenreRepos.Get());
        }
    }
}
