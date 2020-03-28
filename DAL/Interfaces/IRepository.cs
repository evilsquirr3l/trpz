using System.Linq;
using DAL.Models;

namespace DAL
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();

        TEntity GetById(int id);

        void Create(TEntity entity);

        void Delete(TEntity entity);

        void Edit(TEntity entity);
    }
}