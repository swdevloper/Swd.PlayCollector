
using Swd.PlayCollectory.Business.Model;
using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.PlayCollector.Repository
{
    public class CollectionItemRepository
    {

        //CRUD
        //C -> Create (Add)
        //R -> Read (Select)
        //U -> Update (Update)
        //D -> Delete (Delete)



        //ToDo: CollectionItem durch generisches Objekt ersetzen
        //ToDo: PlayCollector durch  generisches Objekt ersetzen
        //ToDo: Fehlerbehandler
        //ToDo: Asynchron
        //ToDo: Logging
        public List<CollectionItem> Select()
        {
            PlayCollectorDb db = new PlayCollectorDb();
            List<CollectionItem> collectionItems = db.CollectionItems.ToList();
            return collectionItems;
        }
        public List<CollectionItem> SelectAsync()
        {
            PlayCollectorDb db = new PlayCollectorDb();
            List<CollectionItem> collectionItems = db.CollectionItems.ToList();
            return collectionItems;
        }

        //ToDo: Schlüsselfeldd durch allgemeines Objekt ersetzen
        public CollectionItem SelectById(long id)
        {
            PlayCollectorDb db = new PlayCollectorDb();
            CollectionItem item = db.CollectionItems.Find(id);
            return item;
        }
        public CollectionItem SelectByIdAsync(long id)
        {
            PlayCollectorDb db = new PlayCollectorDb();
            CollectionItem item = db.CollectionItems.Find(id);
            return item;
        }


        public void Add(CollectionItem item)
        {
            PlayCollectorDb db = new PlayCollectorDb();
            db.CollectionItems.Add(item);
            db.SaveChanges();
        }
        public void AddAsync(CollectionItem item)
        {
            PlayCollectorDb db = new PlayCollectorDb();
            db.CollectionItems.Add(item);
            db.SaveChanges();
        }


        public void Update(CollectionItem item)
        {
            PlayCollectorDb db = new PlayCollectorDb();
            CollectionItem existingItem = db.CollectionItems.Find(item.Id);
            if(existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                db.SaveChanges();
                db.Entry(existingItem).Reload();
            }
        }
        public void UpdateAsync(CollectionItem item)
        {
            PlayCollectorDb db = new PlayCollectorDb();
            CollectionItem existingItem = db.CollectionItems.Find(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                db.SaveChanges();
                db.Entry(existingItem).Reload();
            }
        }


        public void Delete(long id)
        {
            PlayCollectorDb db = new PlayCollectorDb();
            CollectionItem existingItem = db.CollectionItems.Find(id);
            if(existingItem != null)
            {
                db.CollectionItems.Remove(existingItem);
                db.SaveChanges();
            }
        }
        public void DeleteAsync(long id)
        {
            PlayCollectorDb db = new PlayCollectorDb();
            CollectionItem existingItem = db.CollectionItems.Find(id);
            if (existingItem != null)
            {
                db.CollectionItems.Remove(existingItem);
                db.SaveChanges();
            }
        }




    }
}
