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
    public class TimRepo : ITim
    {
        private FudbalskiTurnirContainer _context;
        public TimRepo()
        {
            _context = new FudbalskiTurnirContainer();
        }
        public void AddTim(Tim tim)
        {
            try
            {
                _context.Tims.Add(tim);
                int success = _context.SaveChanges();

                if (success > 0)
                {
                    MessageBox.Show("Uspesno dodat Tim!");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Dodavanje Tima nije uspelo!");
            }
        }

        public void DeleteTim(long id)
        {
            try
            {
                if (id == 0)
                {
                    MessageBox.Show("Nije selektovan Tim!");
                    return;
                }

                Tim tim = _context.Tims.Where(x => x.IdTima == id).FirstOrDefault();
                
                _context.Tims.Remove(tim);
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                MessageBox.Show("Zabranjeno brisanje tima, koji je prijavljen na turnir za vec odigrani mec!");
                throw;
            }
        }

        public void EditTim(Tim tim)
        {
            try
            {
                if (tim == null)
                {
                    MessageBox.Show("Nije selektovan Tim!");
                    return;
                }

                Tim timForChange = _context.Tims.FirstOrDefault(x => x.IdTima == tim.IdTima);

                timForChange.BrojTitula = tim.BrojTitula;
                timForChange.DatumOsnivanja = tim.DatumOsnivanja;
                timForChange.Tip = tim.Tip;

                _context.Entry(timForChange).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                MessageBox.Show("Nije uspela promena Tima");
                throw;
            }
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

        public BindingList<Igrac> GetAllIgraci()
        {
            BindingList<Igrac> Igraci = new BindingList<Igrac>();

            var IgraciAll = _context.Ucesniks_Igrac;

            foreach (var item in IgraciAll)
            {
                Igraci.Add(item);
            }

            return Igraci;
        }

        public BindingList<Trener> GetAllTreneri()
        {
            BindingList<Trener> Treneri = new BindingList<Trener>();

            var TreneriAll = _context.Ucesniks_Trener;

            foreach (var item in TreneriAll)
            {
                Treneri.Add(item);
            }

            return Treneri;
        }
    }
}
