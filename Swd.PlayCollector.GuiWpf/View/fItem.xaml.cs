using Swd.PlayCollector.GuiWpf.ViewModel;
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
using System.Windows.Shapes;

namespace Swd.PlayCollector.GuiWpf.View
{
    /// <summary>
    /// Interaction logic for fItem.xaml
    /// </summary>
    public partial class fItem : Window
    {
        public fItem()
        {
            InitializeComponent();
            this.DataContext = new fItemViewModel(new CollectionItem(), this);
        }


        public fItem(CollectionItem collectionItem):this()
        {
            this.DataContext = new fItemViewModel(collectionItem, this);
        }
    }
}
