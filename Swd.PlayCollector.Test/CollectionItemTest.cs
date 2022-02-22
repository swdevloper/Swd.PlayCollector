using Microsoft.VisualStudio.TestTools.UnitTesting;
using Swd.PlayCollector.Repository;
using Swd.PlayCollectory.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Text;

namespace Swd.PlayCollector.Test
{

    [TestClass]
    public class TestCollectionItem
    {
        //HACK: Notwendig weil SqlProviderServices.dll sonst nicht kopiert wird
        private static string _workAround = typeof(SqlProviderServices).ToString();
     
        
        private TestContext _mytestContext;

        public TestContext TestContext
        {
            get { return _mytestContext; }
            set { _mytestContext = value; }
        }


        [TestMethod]
        [DataRow(0.0)]
        [DataRow(10.0)]
        [DataRow(-10.0)]
        public void Add_CollectionItem(double price)
        {
         
            CollectionItemRepository rep = new CollectionItemRepository();

            
            //Testwerte vorbereiten
            CollectionItem item = GetCollectionItem();
            item.Price = Convert.ToDecimal(price);

            //Test durchführen
            CollectionItemRepository repo = new CollectionItemRepository();
            repo.Add(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }


        [TestMethod]
        public void Select_CollectionItem()
        {
            //Testwerte vorbereiten
            CollectionItem item = GetCollectionItem();

            CollectionItemRepository repo = new CollectionItemRepository();
            repo.Add(item);

            int numberOfRecords = repo.Select().Count;
            Assert.AreNotEqual(0, numberOfRecords);
        }



        [TestMethod]
        public void SelectById_CollectionItem()
        {
            //Testwerte vorbereiten
            CollectionItem item = GetCollectionItem();
            
            CollectionItemRepository repo = new CollectionItemRepository();
            repo.Add(item);

            CollectionItem savedCollectionItem = repo.SelectById(item.Id);
            Assert.IsNotNull(savedCollectionItem);
        }




        [TestMethod]
        public void Update_CollectionItem()
        {
            //TODO Code durch Methodenaufruf ersetzen
            //Testwerte vorbereiten
            string oldName = String.Format("{0}", Guid.NewGuid());

            CollectionItem item = GetCollectionItem();
            item.Name = oldName;

            CollectionItemRepository repo = new CollectionItemRepository();
            repo.Add(item);


            CollectionItem savedCollectionItem = repo.SelectById(item.Id);
            string newName = String.Format("{0}", Guid.NewGuid());
            savedCollectionItem.Name = newName;
            repo.Update(savedCollectionItem);

            CollectionItem updatedItem = repo.SelectById(item.Id);
            Assert.AreNotEqual(oldName, updatedItem.Name);

        }



        [TestMethod]
        public void Delete_CollectionItem()
        {
            //Testwerte vorbereiten
            CollectionItem item = GetCollectionItem();

            CollectionItemRepository repo = new CollectionItemRepository();
            repo.Add(item);

            CollectionItem savedCollectionItem = repo.SelectById(item.Id);
            Assert.IsNotNull(savedCollectionItem);

            repo.Delete(item.Id);

            CollectionItem deletedItem = repo.SelectById(item.Id);
            Assert.IsNull(deletedItem);
        }



        [TestMethod()]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        //[DeploymentItem("D:\\Projekte\\SWDeveloper2021\\Swd.Daten\\Testdaten.mdb")]
        //[DataSource("MyJetDataSource")]
        public void Add_MultipleCollectionItems()
        {
            //Testwerte vorbereiten
            CollectionItem item = GetCollectionItem();
            item.Price = Convert.ToDecimal(TestContext.DataRow[0]);
            

            //Test durchführen
            CollectionItemRepository repo = new CollectionItemRepository();
            repo.Add(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }




        private CollectionItem GetCollectionItem()
        {
            CollectionItem item = new CollectionItem();
            item.Name = String.Format("Test {0}", Guid.NewGuid());
            item.Price = 0;
            item.CreatedBy = "Marcel";
            item.Created = DateTime.Now;
            return item;

        }



    }


}
