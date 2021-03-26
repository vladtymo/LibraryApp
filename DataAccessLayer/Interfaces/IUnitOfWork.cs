using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Book> BookRepos { get; }
        IRepository<Author> AuthorRepos { get; }
        IRepository<Genre> GenreRepos { get; }
        void Save();
    }
}
