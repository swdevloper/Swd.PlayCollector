using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Swd.PlayCollector.Repository
{


    public class GenericRepository<TEntity, TModel> : IGenericRepository<TEntity>
        where TEntity : class, new()
        where TModel : DbContext, new()
    {

        private static readonly ILog Log = LogManager.GetLogger(typeof(GenericRepository<TEntity, TModel>));


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
            try
            {
                Log.Debug(string.Format("{0} Inserting item", MethodBase.GetCurrentMethod().Name));
                EntityHelper.SetObjectProperty("Created", DateTime.Now, t);
                _dbSet.Add(t);
                _context.SaveChanges();
                return t;
            }
            catch (Exception ex)
            {
                Log.Error(string.Format("{0} Error occured ", MethodBase.GetCurrentMethod().Name), ex);
                throw;
            }
        }


        public Task<TEntity> InsertAsync(TEntity t)
        {
            throw new NotImplementedException();
        }



        public ICollection<TEntity> GetAll()
        {
            try
            {
                Log.Debug(string.Format("{0} Getting {1} item", MethodBase.GetCurrentMethod().Name, _dbSet.Count()));
                return _dbSet.ToList();
            }
            catch (Exception ex)
            {
                Log.Error(string.Format("{0} Error occured ", MethodBase.GetCurrentMethod().Name), ex);
                throw;
            }
        }


        public Task<ICollection<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public TEntity GetEntityByKey(object key)
        {
            try
            {
                Log.Debug(string.Format("{0} Getting item", MethodBase.GetCurrentMethod().Name));
                return _dbSet.Find(key);
            }
            catch (Exception ex)
            {
                Log.Error(string.Format("{0} Error occured ", MethodBase.GetCurrentMethod().Name), ex);
                throw;
            }
    
        }

        public Task<TEntity> GetEntityByKeyAsync(object key)
        {
            throw new NotImplementedException();
        }




        public TEntity Update(TEntity t, object key)
        {
            try
            {
                Log.Debug(string.Format("{0} Updating item", MethodBase.GetCurrentMethod().Name));
                TEntity existing = _dbSet.Find(key);
                if (existing != null)
                {
                    Log.Debug(string.Format("{0} Item found", MethodBase.GetCurrentMethod().Name));
                    EntityHelper.SetObjectProperty("Updated", DateTime.Now, t);
                    _context.Entry(existing).CurrentValues.SetValues(t);
                    _context.SaveChanges();
                    _context.Entry(existing).Reload();
                }
                else
                {
                    Log.Warn(string.Format("{0} Item not found", MethodBase.GetCurrentMethod().Name));
                }
                return existing;
            }
            catch (Exception ex)
            {
                Log.Error(string.Format("{0} Error occured ", MethodBase.GetCurrentMethod().Name), ex);
                throw;
            }

        

        }

        public Task<TEntity> UpdateAsync(TEntity t, object key)
        {
            throw new NotImplementedException();
        }


        public void Delete(object key)
        {
            try
            {
                Log.Debug(string.Format("{0} Deleting item", MethodBase.GetCurrentMethod().Name));
                TEntity existing = _dbSet.Find(key);
                if (existing != null)
                {
                    _dbSet.Remove(existing);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Log.Error(string.Format("{0} Error occured ", MethodBase.GetCurrentMethod().Name), ex);
                throw;
            }

        }

        public Task DeleteAsync(object key)
        {
            throw new NotImplementedException();
        }


    }
}
