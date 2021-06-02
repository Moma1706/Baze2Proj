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
    public class SudijaRepo : ISudija
    {
        public void AddSudija(Sudija sudija)
        {
            try
            {
                if (sudija.JMBG <= 0)
                {
                    MessageBox.Show("Jmbg ne moze biti 0 ili manje!");
                    return;
                }
                using (FudbalskiTurnirContainer _context = new FudbalskiTurnirContainer())
                {
                    _context.Ucesniks_Sudija.Add(sudija);
                    int success = _context.SaveChanges();

                    if (success > 0)
                    {
                        MessageBox.Show("Uspesno dodat Sudija!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Dodavanje sudije nije uspelo!");
            }
        }

        public void DeleteSudija(long id)
        {
            try
            {
                if (id == null)
                {
                    MessageBox.Show("Nije selektovan sudija!");
                    return;
                }
                using (FudbalskiTurnirContainer _context = new FudbalskiTurnirContainer())
                {
                    Sudija sudija = _context.Ucesniks_Sudija.Where(x => x.JMBG == id).FirstOrDefault();

                    _context.Ucesniks_Sudija.Remove(sudija);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Nije uspelo brisanje igraca!");
                throw;
            }
        }

        public void EditSudija(Sudija sudija)
        {
            try
            {
                if (sudija == null)
                {
                    MessageBox.Show("Nije selektovan sudija!");
                    return;
                }
                using (FudbalskiTurnirContainer _context = new FudbalskiTurnirContainer())
                {
                    Sudija sudijaForChange = _context.Ucesniks_Sudija.Where(x => x.JMBG == sudija.JMBG).FirstOrDefault();

                    sudijaForChange.DatumRodjenja = sudija.DatumRodjenja;
                    sudijaForChange.Drzava = sudija.Drzava;
                    sudijaForChange.Ime = sudija.Ime;
                    sudijaForChange.Prezime = sudija.Prezime;
                    sudijaForChange.Zarada = sudija.Zarada;
                    sudijaForChange.BrojUtakmica = sudija.BrojUtakmica;

                    _context.Entry(sudijaForChange).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Nije uspela promena Sudije");
                throw;
            }
        }

        public BindingList<Sudija> GetAllSudije()
        {
            BindingList<Sudija> Sudije = new BindingList<Sudija>();

            using (FudbalskiTurnirContainer _context = new FudbalskiTurnirContainer())
            {
                var SudijaAll = _context.Ucesniks_Sudija;

                foreach (var item in SudijaAll)
                {
                    Sudije.Add(item);
                }
            }
            return Sudije;
        }
    }
}
