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
        public void AddTurnir(Turnir turnir, List<Tim> timovi)
        {
            try
            {
                _context.Turnirs.Add(turnir);
                int success = _context.SaveChanges();

                if (success > 0)
                {
                    foreach (var item in timovi)
                    {
                        SeKvalifikuje seKvalifikuje = new SeKvalifikuje();
                        seKvalifikuje.Tim = item;
                        seKvalifikuje.Turnir = turnir;

                        turnir.SeKvalifikujes.Add(seKvalifikuje);
                    }
                    success = _context.SaveChanges();
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
            try
            {
                if (id == 0)
                {
                    MessageBox.Show("Nije selektovan Turnir!");
                    return;
                }

                Turnir turnir = _context.Turnirs.Where(x => x.IdTurnira == id).FirstOrDefault();

                turnir.SeKvalifikujes.Clear();
                _context.Turnirs.Remove(turnir);
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                MessageBox.Show("Nije uspelo brisanje sponzora!");
                throw;
            }
        }

        public void EditTurnir(Turnir turnir)
        {
            try
            {
                if (turnir == null)
                {
                    MessageBox.Show("Nije selektovan Turnir!");
                    return;
                }

                Turnir turnirForChange = _context.Turnirs.FirstOrDefault(x => x.IdTurnira == turnir.IdTurnira);

                turnirForChange.Naziv = turnir.Naziv;
                turnirForChange.Tip = turnir.Tip;
                turnirForChange.TrenutniSampion = turnir.TrenutniSampion;
                turnirForChange.DatumOsnivanja = turnir.DatumOsnivanja;

                _context.Entry(turnirForChange).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                MessageBox.Show("Nije uspela promena Turnir");
                throw;
            };
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

        public BindingList<Tim> GetAllTimovi()
        {
            BindingList<Tim> Timovi = new BindingList<Tim>();

            var TimoviAll = _context.Tims;

            foreach (var item in TimoviAll)
            {
                Timovi.Add(item);
            }

            return Timovi;
        }
    }
}
