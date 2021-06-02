using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface ISponzor
    {
        BindingList<Sponzor> GetAllSponzori();
        void AddSponzor(Sponzor sponzor);
        void EditSponzor(Sponzor sponzor);
        void DeleteSponzor(int id);
    }
}
