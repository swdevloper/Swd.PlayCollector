using playcollector.gui.wpf.Model;
using Swd.PlayCollector.Business;
using Swd.PlayCollector.GuiWpf.Model;
using Swd.PlayCollector.GuiWpf.View;
using Swd.PlayCollectory.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Swd.PlayCollector.GuiWpf.ViewModel
{
    public class fMainViewModel: ObservableView
    {
    
        List<CollectionItem> _collectionItemList = new List<CollectionItem>();
        string _statusText = string.Empty;
        string _appCommandTextCollection = string.Empty;
        string _appCommandTextSettings = string.Empty;
        CollectionItem _selectedCollectionItem;
        string _searchItemText;

        
         
        public List<CollectionItem> CollectionItemList
            {
            get { return _collectionItemList; }
            set
            {
                _collectionItemList = value;
                PropertyHasChanged("CollectionItemList");
            }
        }




        //Commands
        public RelayCommand AddCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }


        public CollectionItem SelectedCollectionItem
        {
            get { return _selectedCollectionItem; }
            set { 
                _selectedCollectionItem = value;
                if(_selectedCollectionItem!= null)
                {
                    StatusText = string.Format("{0} {1}", _selectedCollectionItem.Number, _selectedCollectionItem.Name);
                }
                else
                {
                    StatusText = string.Empty;
                }
                PropertyHasChanged("SelectedCollectionItem");
            }
        }

        //Search
        public string SearchItemText
        {
            get { return _searchItemText; }
            set
            {
                _searchItemText = value;
                CollectionItemManager manager = new CollectionItemManager();
                int numericValue = 0;
                if(int.TryParse(_searchItemText, out numericValue))
                {
                    CollectionItemList = manager.GetAll().Where(item => item.Number.Contains(_searchItemText)).ToList();
                }
                else
                {
                    CollectionItemList = manager.GetAll().Where(item => item.Name.ToLower().Contains(_searchItemText.ToLower())).ToList();
                }
                PropertyHasChanged("SearchItemText");
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
            fItem f = new fItem();
            f.Show();
        }



        public void EditItem()
        {
            fItem f = new fItem(SelectedCollectionItem);
            f.Show();
        }


        public void DeleteItem()
        {
            DialogResult result = MessageBox.Show(string.Format("Wollen Sie das Objekt {0} wirklich löschen?", SelectedCollectionItem.Name), "Objekt löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if(result==DialogResult.Yes)
            {
                CollectionItemManager manager = new CollectionItemManager();
                manager.Delete(SelectedCollectionItem.Id);
                CollectionItemList = manager.GetAll().ToList();
            }
        }



    }
}
