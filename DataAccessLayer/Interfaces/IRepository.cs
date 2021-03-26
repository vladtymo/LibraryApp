using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // [C]reate
        // [R]ead
        // [U]pdate
        // [D]elete
        TEntity GetById(int id);
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        void Update(TEntity entityToUpdate);
        void Insert(TEntity entity);
        void Delete(TEntity entityToDelete);
        void Delete(int id);
    }
}
