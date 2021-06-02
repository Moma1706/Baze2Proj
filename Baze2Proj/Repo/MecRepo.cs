using Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baze2Proj.Repo
{
    public class MecRepo : IMec
    {
        private FudbalskiTurnirContainer _context;
        public MecRepo()
        {
            _context = new FudbalskiTurnirContainer();
        }
        public void AddMec(Mec mec)
        {
            throw new NotImplementedException();
        }

        public void DeleteMec(long id)
        {
            throw new NotImplementedException();
        }

        public void EditMec(Mec mec)
        {
            throw new NotImplementedException();
        }

        public BindingList<Mec> GetAllMecevi()
        {
            BindingList<Mec> Mecevi = new BindingList<Mec>();

            var MeceviAll = _context.Mecs;

            foreach (var item in MeceviAll)
            {
                Mecevi.Add(item);
            }

            return Mecevi;
        }
    }
}
