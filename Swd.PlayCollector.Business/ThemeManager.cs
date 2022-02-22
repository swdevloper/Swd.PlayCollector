using Swd.PlayCollector.Repository;
using Swd.PlayCollectory.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.PlayCollector.Business
{


    public class ThemeManager
    {

        private IThemeRepository _IRepository;


        public ThemeManager()
        {
            _IRepository = new ThemeRepository();  
        }

        
        public Theme Insert(Theme item)
        {
            return _IRepository.Insert(item);
        }

        public ICollection<Theme> GetAll()
        {
            return _IRepository.GetAll();   
        }

        public Theme GetEntityByKey(object key)
        {
            return _IRepository.GetEntityByKey(key);
        }

        public Theme Update(Theme item)
        {
            return _IRepository.Update(item, item.Id);
        }

        public void Delete(object key)
        {
            _IRepository.Delete(key);
        }


    }
}
