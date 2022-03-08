using Swd.PlayCollector.Business;
using Swd.PlayCollectory.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Swd.PlayCollector.GuiWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadItems();
        }


        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadItems();
        }


        private void lstItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                CollectionItem selectedItem = e.AddedItems[0] as CollectionItem;
                txbNumber.Text = selectedItem.Number; 
                txbName.Text = selectedItem.Name;   
            }
        }


        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            CollectionItemManager manager = new CollectionItemManager();
            CollectionItem item = lstItem.SelectedItem as CollectionItem;
            if (item != null)
            {
                item.Number = txbNumber.Text;
                item.Name = txbName.Text;
                manager.Update(item);
            }
            else
            {
                item = new CollectionItem();
                item.Number = txbNumber.Text;
                item.Name = txbName.Text;
                item.Created = DateTime.Now;
                item.CreatedBy = WindowsIdentity.GetCurrent().Name;
                manager.Insert(item);   
            }
            LoadItems();
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CollectionItemManager manager = new CollectionItemManager();
            CollectionItem item = lstItem.SelectedItem as CollectionItem;
            if (item != null)
            {
                manager.Delete(item.Id);
                LoadItems();
                ClearFields();
            }
        }




        private void LoadItems()
        {
            CollectionItemManager manager = new CollectionItemManager();
            List<CollectionItem> itemList = manager.GetAll().ToList();
            this.lstItem.ItemsSource = itemList;
        }


        private void ClearFields()
        {
            lstItem.SelectedItem = null;
            txbName.Text = String.Empty;
            txbNumber.Text = String.Empty;

        }


    }
}
