using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IStatistika
    {
        BindingList<Statistika> GetAllStatistike();
        void AddStatistika(Statistika statistika);
        void EditStatistika(Statistika statistika);
        void DeleteStatistika(int id);
    }
}
