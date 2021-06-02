using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface ITeren
    {
        BindingList<Teren> GetAllTereni();
        void AddTeren(Teren teren);
        void EditTeren(Teren teren);
        void DeleteTeren(int id);
    }
}
