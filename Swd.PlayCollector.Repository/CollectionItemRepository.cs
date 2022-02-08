
using Swd.PlayCollectory.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.PlayCollector.Repository
{
    public class CollectionItemRepository
    {



        public void Add(CollectionItem item)
        {
            PlayCollectorDb db = new PlayCollectorDb(); 
            db.CollectionItems.Add(item);
            db.SaveChanges();
        }



    }
}
