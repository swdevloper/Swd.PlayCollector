using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.PlayCollectory.Business.Model
{
    [AddINotifyPropertyChangedInterface]
    public partial class CollectionItem
    {

        public string DisplayName {
            get { return string.Format("{0} {1}", Number, Name); }
        }


        public void OnPropertyChanged(string propertyName, object before, object after)
        {

        }
    }
}
