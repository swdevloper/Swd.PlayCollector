using playcollector.gui.wpf.Model;
using Swd.PlayCollector.Business;
using Swd.PlayCollector.GuiWpf.Model;
using Swd.PlayCollectory.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Swd.PlayCollector.GuiWpf.ViewModel
{

    public class fItemViewModel: ObservableView
    {
        CollectionItem _selectedCollectionItem;
        List<Theme> _themeList;
        string _errorMessage;
        Window _currentWindow;



        public CollectionItem SelectedCollectionItem
        {
            get { return _selectedCollectionItem; }
            set
            {
                _selectedCollectionItem = value;
                PropertyHasChanged("SelectedCollectionItem");
            }
        }

        public List<Theme> ThemeList
        {
            get { return _themeList; }
            set
            {
                _themeList = value;
                PropertyHasChanged("ThemeList");
            }
        }

        public String ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                PropertyHasChanged("ErrorMessage");
            }
        }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }



        public fItemViewModel(CollectionItem collectionItem, Window currentWindow)
        {
            _currentWindow = currentWindow;
            SelectedCollectionItem = collectionItem;
            ErrorMessage = string.Empty;
            ThemeManager manager = new ThemeManager();
            ThemeList = manager.GetAll().OrderBy(item => item.Name).ToList();

            SaveCommand = new RelayCommand(c => { SaveItem(); }, c => true);
            CancelCommand = new RelayCommand(c => { Cancel(); }, c => true);
        }


        public void SaveItem()
        {
            CollectionItemValidator validator = new CollectionItemValidator();
            var result = validator.Validate(SelectedCollectionItem);
            if(result.IsValid==false)
            {
                string errorMessage = string.Empty;
                foreach (var error in result.Errors)
                {
                    errorMessage += string.Format("{0}: {1} {2}", error.PropertyName, error.ErrorMessage, Environment.NewLine);
                }
                ErrorMessage = errorMessage;
            }
            else
            { 
                CollectionItemManager manager = new CollectionItemManager();
                if (SelectedCollectionItem.Id == 0)
                {
                    SelectedCollectionItem.CreatedBy = WindowsIdentity.GetCurrent().Name;
                    manager.Insert(SelectedCollectionItem);
                }
                else
                {
                    manager.Update(SelectedCollectionItem);
                }
                _currentWindow.Close();
            }
        }


        public void Cancel()
        {
            _currentWindow.Close();
        }
    }
}
