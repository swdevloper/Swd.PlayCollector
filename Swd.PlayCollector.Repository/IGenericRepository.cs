using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.PlayCollector.Repository
{


    public interface IGenericRepository<TEntity> where TEntity : class, new()
    {

        DbSet<TEntity> DbSet { get; }


        #region [C]reate-Methodes
        TEntity Insert(TEntity t);
        Task<TEntity> InsertAsync(TEntity t);
        #endregion


        #region [R]ead-Methodes
        ICollection<TEntity> GetAll();
        Task<ICollection<TEntity>> GetAllAsync();

        TEntity GetEntityByKey(object key);
        Task<TEntity> GetEntityByKeyAsync(object key);
        #endregion


        #region [U]pdate-Methodes
        TEntity Update(TEntity t, object key);
        Task<TEntity> UpdateAsync(TEntity t, object key);
        #endregion


        #region [D]elete-Methodes
        void Delete(object key);
        Task DeleteAsync(object key);
        #endregion


    }

}
