using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IIgrac
    {
        BindingList<Igrac> GetAllIgraci();
        void AddIgrac(Igrac igrac);
        void EditIgrac(Igrac igrac);
        void DeleteIgrac(long id);
    }
}
