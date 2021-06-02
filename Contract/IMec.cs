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
        void AddMec(Mec mec);
        void EditMec(Mec mec);
        void DeleteMec(long id);
    }
}
