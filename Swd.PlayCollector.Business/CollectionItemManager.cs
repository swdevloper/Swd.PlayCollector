using Swd.PlayCollector.Repository;
using Swd.PlayCollectory.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.PlayCollector.Business
{


    public class CollectionItemManager
    {

        private ICollectionItemRepository _IRepository;


        public CollectionItemManager()
        {
            _IRepository = new CollectionItemRepository();  
        }

        
        public CollectionItem Insert(CollectionItem item)
        {
            return _IRepository.Insert(item);
        }

        public ICollection<CollectionItem> GetAll()
        {
            return _IRepository.GetAll();   
        }

        public CollectionItem GetEntityByKey(object key)
        {
            return _IRepository.GetEntityByKey(key);
        }

        public CollectionItem Update(CollectionItem item)
        {
            return _IRepository.Update(item, item.Id);
        }

        public void Delete(object key)
        {
            _IRepository.Delete(key);
        }


    }
}
