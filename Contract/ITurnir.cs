using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface ITurnir
    {
        BindingList<Turnir> GetAllTurniri();
        void AddTurnir(Turnir turnir, List<Tim> timovi);
        void EditTurnir(Turnir turnir);
        void DeleteTurnir(long id);
        BindingList<Sponzor> GetAllSponzori();
    }
}
