using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
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
        }

        public IEnumerable<GenreDTO> GetAllGenres()
        {
            return mapper.Map<IEnumerable<GenreDTO>>(repositroties.GenreRepos.Get());
        }
    }
}
