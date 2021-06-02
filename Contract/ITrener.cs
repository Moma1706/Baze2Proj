using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface ITrener
    {
        BindingList<Trener> GetAllTreneri();
        void AddTrener(Trener trener);
        void EditTrener(Trener   trener);
        void DeleteTrener(long id);
    }
}
