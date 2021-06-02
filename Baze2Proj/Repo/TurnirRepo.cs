using Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Baze2Proj.Repo
{
    public class TurnirRepo : ITurnir
    {
        private FudbalskiTurnirContainer _context;
        public TurnirRepo()
        {
            _context = new FudbalskiTurnirContainer();
        }
        public void AddTurnir(Turnir turnir)
        {
            try
            {
                _context.Turnirs.Add(turnir);
                int success = _context.SaveChanges();

                if (success > 0)
                {
                    MessageBox.Show("Uspesno dodat Turnir!");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Dodavanje igraca nije uspelo!");
            }

        }

        public void DeleteTurnir(long id)
        {
            throw new NotImplementedException();
        }

        public void EditTurnir(Turnir turnir)
        {
            throw new NotImplementedException();
        }

        public BindingList<Turnir> GetAllTurniri()
        {
            BindingList<Turnir> Turniri = new BindingList<Turnir>();

            var TurniriAll = _context.Turnirs;

            foreach (var item in TurniriAll)
            {
                Turniri.Add(item);
            }
            
            return Turniri;
        }

        public BindingList<Sponzor> GetAllSponzori()
        {
            BindingList<Sponzor> Sponzori = new BindingList<Sponzor>();

            var SponzoriAll = _context.Sponzors;

            foreach (var item in SponzoriAll)
            {
                Sponzori.Add(item);
            }

            return Sponzori;
        }
    }
}
