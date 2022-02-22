using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.PlayCollector.Repository
{


    public class GenericRepository<TEntity, TModel> : IGenericRepository<TEntity>
        where TEntity : class, new()
        where TModel : DbContext, new()
    {

        //Members
        private DbContext _context;
        private DbSet<TEntity> _dbSet;


        //Properties
        public DbSet<TEntity> DbSet
        {
            get { return _dbSet; }
        } 



        //Constructors
        public GenericRepository()
        {
            Init(new TModel());
        }

        public GenericRepository(DbContext context)
        {
            Init(context);
        }




        public void Init(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }





        public TEntity Insert(TEntity t)
        {
            _dbSet.Add(t);
            _context.SaveChanges();
            return t;

        }

        public Task<TEntity> InsertAsync(TEntity t)
        {
            throw new NotImplementedException();
        }



        public ICollection<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public Task<ICollection<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public TEntity GetEntityByKey(object key)
        {
            return _dbSet.Find(key);
        }

        public Task<TEntity> GetEntityByKeyAsync(object key)
        {
            throw new NotImplementedException();
        }




        public TEntity Update(TEntity t, object key)
        {
            
            TEntity existing = _dbSet.Find(key);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(t);
                _context.SaveChanges();
                _context.Entry(existing).Reload();
            }
            return existing;

        }

        public Task<TEntity> UpdateAsync(TEntity t, object key)
        {
            throw new NotImplementedException();
        }


        public void Delete(object key)
        {
            TEntity existing = _dbSet.Find(key);
            if (existing != null)
            {
                _dbSet.Remove(existing);
                _context.SaveChanges();
            }
        }

        public Task DeleteAsync(object key)
        {
            throw new NotImplementedException();
        }


    }
}
