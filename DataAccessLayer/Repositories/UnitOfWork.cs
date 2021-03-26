using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private LibraryModel context = new LibraryModel();
        private GenericRepository<Book> bookRepository;
        private GenericRepository<Author> authorRepository;
        private GenericRepository<Genre> genreRepository;

        public IRepository<Book> BookRepos
        {
            get
            {
                // repository lazy loading
                if (this.bookRepository == null)
                {
                    this.bookRepository = new GenericRepository<Book>(context);
                }
                return bookRepository;
            }
        }
        public IRepository<Author> AuthorRepos
        {
            get
            {
                if (this.authorRepository == null)
                {
                    this.authorRepository = new GenericRepository<Author>(context);
                }
                return authorRepository;
            }
        }
        public IRepository<Genre> GenreRepos
        {
            get
            {
                if (this.genreRepository == null)
                {
                    this.genreRepository = new GenericRepository<Genre>(context);
                }
                return genreRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
