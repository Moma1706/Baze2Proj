using Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            try
            {
                SePrijavljuje sePrijavljuje = new SePrijavljuje();

                var sudija = _context.Ucesniks_Sudija.FirstOrDefault(x => x.JMBG == mec.SePrijavljujeSudijaJMBG);
                var turnir = _context.Turnirs.FirstOrDefault(x => x.IdTurnira == mec.SePrijavljujeTurnirIdTurnira);

                sePrijavljuje.Sudija = sudija;
                sePrijavljuje.Turnir = turnir;

                mec.SePrijavljuje = sePrijavljuje;
                _context.Mecs.Add(mec);

                int success = _context.SaveChanges();

                if (success > 0)
                {
                    MessageBox.Show("Uspesno dodat Mec!");
                }
            }
            
            catch (Exception e)
            {
                MessageBox.Show("Dodavanje Statistike nije uspelo!");
            }
        }

        public void DeleteMec(int id)
        {
            try
            {
                if (id == 0)
                {
                    MessageBox.Show("Nije selektovan mec!");
                    return;
                }

                Mec mec = _context.Mecs.Where(x => x.IdMeca == id).FirstOrDefault();


                _context.Mecs.Remove(mec);
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                MessageBox.Show("Nije uspelo brisanje meca!");
                throw;
            }
        }

        public void EditMec(Mec mec)
        {
            try
            {
                if (mec == null)
                {
                    MessageBox.Show("Nije selektovan Mec!");
                    return;
                }

                Mec mecForChange = _context.Mecs.FirstOrDefault(x => x.IdMeca == mec.IdMeca);

                mecForChange.Kolo = mec.Kolo;
                mecForChange.DatumOdrzavanja = mec.DatumOdrzavanja;
                mecForChange.Rezultat = mec.Rezultat;

                _context.Entry(mecForChange).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                MessageBox.Show("Nije uspela promena igraca");
                throw;
            }
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
        public BindingList<Sudija> GetAllSudije()
        {
            BindingList<Sudija> Sudije = new BindingList<Sudija>();

            var SudijeAll = _context.Ucesniks_Sudija;

            foreach (var item in SudijeAll)
            {
                Sudije.Add(item);
            }

            return Sudije;
        }

        public BindingList<Turnir > GetAllTurniri()
        {
            BindingList<Turnir> turniri = new BindingList<Turnir>();

            var TurniriAll = _context.Turnirs;

            foreach (var item in TurniriAll)
            {
                turniri.Add(item);
            }

            return turniri;
        }

        public BindingList<Teren> GetAllTereni()
        {
            BindingList<Teren> tereni = new BindingList<Teren>();

            var TereniAll = _context.Terens;

            foreach (var item in TereniAll)
            {
                tereni.Add(item);
            }

            return tereni;
        }

        public BindingList<Statistika> GetAllStatistike()
        {
            BindingList<Statistika> statistike = new BindingList<Statistika>();

            var statistikeAll = _context.Statistikas;

            foreach (var item in statistikeAll)
            {
                statistike.Add(item);
            }

            return statistike;
        }

        public Sudija GetSudija(string name)
        {
            return _context.Ucesniks_Sudija.Where(x => x.Ime == name).FirstOrDefault();
        }
        public Turnir GetTurnir(string name)
        {
            return _context.Turnirs.Where(x => x.Naziv == name).FirstOrDefault();
        }
        public Teren GetTeren(string name)
        {
            return _context.Terens.Where(x => x.Naziv == name).FirstOrDefault();
        }

    }
}
