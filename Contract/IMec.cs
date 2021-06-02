using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IMec
    {
        BindingList<Mec> GetAllMecevi();
        BindingList<Sudija> GetAllSudije();
        BindingList<Statistika> GetAllStatistike();
        BindingList<Teren> GetAllTereni();
        void AddMec(Mec mec);
        void EditMec(Mec mec);
        void DeleteMec(int id);
    }
}
