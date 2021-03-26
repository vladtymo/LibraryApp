using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{

    public class BookService
    {
        private IUnitOfWork repositories;
        private IMapper mapper;
        public BookService()
        {
            this.repositories = new UnitOfWork();

            IConfigurationProvider config = new MapperConfiguration(
                cfg =>
                {
                    // Entity to DTO
                    cfg.CreateMap<Book, BookDTO>()
                        .ForMember(dst => dst.GenreName, opt => opt.MapFrom(src => src.Genre.Name));

                    cfg.CreateMap<Author, AuthorDTO>();
                });

            mapper = new Mapper(config);
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            var result = repositories.BookRepos.Get(includeProperties: $"{nameof(Book.Genre)},{nameof(Book.Author)}");
            return mapper.Map<IEnumerable<BookDTO>>(result);

            // manual converter
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

        public void CreateNewBook(BookDTO bookDTO)
        {
            repositories.BookRepos.Insert(mapper.Map<Book>(bookDTO));
        }
    }
}
