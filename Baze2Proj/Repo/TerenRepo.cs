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
    public class TerenRepo : ITeren
    {
        private FudbalskiTurnirContainer _context;
        public TerenRepo()
        {
            _context = new FudbalskiTurnirContainer();
        }
        public void AddTeren(Teren teren)
        {
            try
            {
                _context.Terens.Add(teren);
                int success = _context.SaveChanges();

                if (success > 0)
                {
                    MessageBox.Show("Uspesno dodat Teren!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Dodavanje Terena nije uspelo!");
            }
        }

        public void DeleteTeren(int id)
        {
            try
            {
                if (id == 0)
                {
                    MessageBox.Show("Nije selektovan Teren!");
                    return;
                }

                Teren teren = _context.Terens.FirstOrDefault(x => x.IdTerena == id);

                _context.Terens.Remove(teren);
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                MessageBox.Show("Nije uspelo brisanje Terena!");
                throw;
            }
        }

        public void EditTeren(Teren teren)
        {
            try
            {
                if (teren == null)
                {
                    MessageBox.Show("Nije selektovan Teren!");
                    return;
                }

                Teren terenForChange = _context.Terens.FirstOrDefault(x => x.IdTerena == teren.IdTerena);

                terenForChange.Mesto = teren.Mesto;
                terenForChange.Naziv = teren.Naziv;
                terenForChange.BrojGledalaca = teren.BrojGledalaca;
                terenForChange.DatumOsnivanja = teren.DatumOsnivanja;

                _context.Entry(terenForChange).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                MessageBox.Show("Nije uspela promena Statistike");
                throw;
            }
        }

        public BindingList<Teren> GetAllTereni()
        {
            BindingList<Teren> Tereni = new BindingList<Teren>();

            var TereniAll = _context.Terens;

            foreach (var item in TereniAll)
            {
                Tereni.Add(item);
            }

            return Tereni;
        }
    }
}
