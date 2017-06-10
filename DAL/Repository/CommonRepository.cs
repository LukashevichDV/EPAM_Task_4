using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repository
{
    public class CommonRepository<TEntity> : IDisposable
        where TEntity : Entity.Entity
    {
        private readonly DbContext DBContext;
        private bool Disposed = false;


        protected IDbSet<TEntity> DbSet => DBContext.Set<TEntity>();


        public CommonRepository(DbContext dbContext)
        {
            DBContext = dbContext;
        }


        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }


        public void Create(TEntity item)
        {
            DbSet.Add(item);
        }


        public TEntity GetById(int id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }


        public void Update(TEntity item)
        {
            DBContext.Entry(item).State = EntityState.Modified;
        }


        public void Delete(int id)
        {
            var item = DbSet.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                DbSet.Remove(item);
            }
        }


        public void Save()
        {
            DBContext.SaveChanges();
        }


        public virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    DBContext.Dispose();
                }
            }
            Disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}