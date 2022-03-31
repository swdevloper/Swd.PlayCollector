using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.PlayCollector.GuiWpf.Model
{
    public class ObservableView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;



        protected void PropertyHasChanged(string property)
        {
            if(property != null)
            {
                if (TypeDescriptor.GetProperties(this)[property] !=null)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));  
                }
            }
        }





        public ObservableView()
        {


        }

    }
}
