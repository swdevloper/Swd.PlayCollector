using Swd.PlayCollector.Business;
using Swd.PlayCollectory.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.PlayCollector.GuiWpf.ViewModel
{
    public class fMainViewModel
    {

        List<CollectionItem> _collectionItemList = new List<CollectionItem>();
        string _statusText = string.Empty;
        string _appCommandTextCollection = string.Empty;
        string _appCommandTextSettings = string.Empty;

        public List<CollectionItem> CollectionItemList { get => _collectionItemList; set => _collectionItemList = value; }


        public string StatusText
        {
            get { return _statusText; }
            set { _statusText = value; }
        }
        public string AppCommandTextSettings
        {
            get { return _appCommandTextSettings; }
            set { _appCommandTextSettings = value; }
        }
        public string AppCommandTextCollection
        {
            get { return _appCommandTextCollection; }
            set { _appCommandTextCollection = value; }
        }




        public fMainViewModel()
        {
            CollectionItemManager manager = new CollectionItemManager();
            CollectionItemList = manager.GetAll().ToList();

            StatusText = "Ready";
            AppCommandTextSettings = "Einstellung";
            AppCommandTextCollection = "Sammlung";

        }

        
    }
}
