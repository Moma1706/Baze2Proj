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
    public class TrenerRepo : ITrener
    {
        public void AddTrener(Trener trener)
        {
            try
            {
                if (trener.JMBG <= 0)
                {
                    MessageBox.Show("Jmbg ne moze biti 0 ili manje!");
                    return;
                }
                using (FudbalskiTurnirContainer _context = new FudbalskiTurnirContainer())
                {
                    _context.Ucesniks_Trener.Add(trener);
                    int success = _context.SaveChanges();

                    if (success > 0)
                    {
                        MessageBox.Show("Uspesno dodat Trener!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Dodavanje Trenera nije uspelo!");
            }
        }

        public void DeleteTrener(long id)
        {
            try
            {
                if (id == null)
                {
                    MessageBox.Show("Nije selektovan Trener!");
                    return;
                }
                using (FudbalskiTurnirContainer _context = new FudbalskiTurnirContainer())
                {
                    Trener trener = _context.Ucesniks_Trener.Where(x => x.JMBG == id).FirstOrDefault();

                    _context.Ucesniks_Trener.Remove(trener);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Nije uspelo brisanje Trenera!");
                throw;
            }
        }

        public void EditTrener(Trener trener)
        {
            try
            {
                if (trener == null)
                {
                    MessageBox.Show("Nije selektovan Trener!");
                    return;
                }
                using (FudbalskiTurnirContainer _context = new FudbalskiTurnirContainer())
                {
                    Trener trenerForChange = _context.Ucesniks_Trener.Where(x => x.JMBG == trener.JMBG).FirstOrDefault();

                    trenerForChange.BrojOsvojenihTitula = trener.BrojOsvojenihTitula;
                    trenerForChange.DatumRodjenja = trener.DatumRodjenja;
                    trenerForChange.Drzava = trener.Drzava;
                    trenerForChange.Ime = trener.Ime;
                    trenerForChange.Zarada = trener.Zarada;
                    trenerForChange.Prezime = trener.Prezime;
                    trenerForChange.Tip = trener.Tip;


                    _context.Entry(trenerForChange).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Nije uspela promena trenera");
                throw;
            }
        }

        public BindingList<Trener> GetAllTreneri()
        {
            BindingList<Trener> Treneri = new BindingList<Trener>();

            using (FudbalskiTurnirContainer _context = new FudbalskiTurnirContainer())
            {
                var TreneriAll = _context.Ucesniks_Trener;

                foreach (var item in TreneriAll)
                {
                    Treneri.Add(item);
                }
            }
            return Treneri;
        }
    }
}
