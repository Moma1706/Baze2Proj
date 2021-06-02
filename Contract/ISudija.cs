using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface ISudija
    {
        BindingList<Sudija> GetAllSudije();
        void AddSudija(Sudija sudija);
        void EditSudija(Sudija sudija);
        void DeleteSudija(long id);
    }
}
