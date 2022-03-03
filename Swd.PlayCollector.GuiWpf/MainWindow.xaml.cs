using Swd.PlayCollector.Business;
using Swd.PlayCollectory.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadItems();
        }



        private void LoadItems()
        {
            CollectionItemManager manager = new CollectionItemManager();
            List<CollectionItem> itemList = manager.GetAll().ToList();
            this.lstItem.ItemsSource = itemList;

        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            txbName.Text = String.Empty;
            txbNumber.Text= String.Empty;
        }
    }
}
