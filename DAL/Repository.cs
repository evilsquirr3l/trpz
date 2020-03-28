using System.Linq;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Edit(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}