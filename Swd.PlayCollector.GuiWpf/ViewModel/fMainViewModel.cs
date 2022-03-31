using playcollector.gui.wpf.Model;
using Swd.PlayCollector.Business;
using Swd.PlayCollector.GuiWpf.Model;
using Swd.PlayCollectory.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.PlayCollector.GuiWpf.ViewModel
{
    public class fMainViewModel: ObservableView
    {
    
        List<CollectionItem> _collectionItemList = new List<CollectionItem>();
        string _statusText = string.Empty;
        string _appCommandTextCollection = string.Empty;
        string _appCommandTextSettings = string.Empty;
        CollectionItem _selectedCollectionItem;

        public List<CollectionItem> CollectionItemList { get => _collectionItemList; set => _collectionItemList = value; }

        //Commands
        public RelayCommand AddCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }


        public CollectionItem SelectedCollectionItem
        {
            get { return _selectedCollectionItem; }
            set { 
                _selectedCollectionItem = value;
                StatusText = string.Format("{0} {1}",_selectedCollectionItem.Number, _selectedCollectionItem.Name);
                PropertyHasChanged("SelectedCollectionItem");
            }
        }



        //Text
        public string StatusText
        {
            get { return _statusText; }
            set { 
                _statusText = value;
                PropertyHasChanged("StatusText");
                }
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

            StatusText = String.Empty;
            AppCommandTextSettings = "Einstellung";
            AppCommandTextCollection = "Sammlung";


            AddCommand = new RelayCommand(c => { AddItem(); }, c => true);
            EditCommand = new RelayCommand(c => { EditItem(); }, c => SelectedCollectionItem!=null);
            DeleteCommand = new RelayCommand(c => { DeleteItem(); }, c => SelectedCollectionItem != null);

        }


        public void AddItem()
        {

        }



        public void EditItem()
        {
            
        }


        public void DeleteItem()
        {
            
        }



    }
}
