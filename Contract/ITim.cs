using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface ITim
    {
        BindingList<Tim> GetAllTimovi();
        void AddTim(Tim tim);
        void EditTim(Tim tim);
        void DeleteTim(long id);
    }
}
