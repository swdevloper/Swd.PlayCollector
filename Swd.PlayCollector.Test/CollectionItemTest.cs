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
        //HACK
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
            //Testwerte vorbereiten
            CollectionItem item = new CollectionItem();
            item.Name = String.Format("CollectionItem Test {0}", DateTime.Now);
            item.Price = Convert.ToDecimal(price);
            item.CreatedBy = "Marcel";
            item.Created = DateTime.Now;

            //Test durchführen
            CollectionItemRepository repo = new CollectionItemRepository();
            repo.Add(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }


        [TestMethod()]
        [DeploymentItem("D:\\Projekte\\SWDeveloper2021\\Swd.Daten\\Testdaten.mdb")]
        [DataSource("MyJetDataSource")]
        public void Add_MultipleCollectionItems()
        {
            //Testwerte vorbereiten
            CollectionItem item = new CollectionItem();
            item.Name = String.Format("CollectionItem Test {0}", DateTime.Now);
            item.Price = Convert.ToDecimal(TestContext.DataRow[0]);
            item.CreatedBy = "Marcel";
            item.Created = DateTime.Now;

            //Test durchführen
            CollectionItemRepository repo = new CollectionItemRepository();
            repo.Add(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }


    }


}
