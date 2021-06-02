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
    public class IgracRepo : IIgrac
    {

        public IgracRepo()
        {

        }

        public void AddIgrac(Igrac igrac)
        {
            try
            {
                if (igrac.JMBG <= 0)
                {
                    MessageBox.Show("Jmbg ne moze biti 0 ili manje!");
                    return;
                }
                using (FudbalskiTurnirContainer _context = new FudbalskiTurnirContainer())
                {
                    _context.Ucesniks_Igrac.Add(igrac);
                    int success = _context.SaveChanges();

                    if(success > 0)
                    {
                        MessageBox.Show("Uspesno dodat Igrac!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Dodavanje igraca nije uspelo!");
            }
        }

        public void DeleteIgrac(long id)
        {
            try
            {
                if (id == null)
                {
                    MessageBox.Show("Nije selektovan igrac!");
                    return;
                }
                using (FudbalskiTurnirContainer _context = new FudbalskiTurnirContainer())
                {
                    Igrac igrac = _context.Ucesniks_Igrac.Where(x => x.JMBG == id).FirstOrDefault();

                    _context.Ucesniks_Igrac.Remove(igrac);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Nije uspelo brisanje igraca!");
                throw;
            }
        }

        public void EditIgrac(Igrac igrac)
        {
            try
            {
                if(igrac == null)
                {
                    MessageBox.Show("Nije selektovan igrac!");
                    return;
                }
                using (FudbalskiTurnirContainer _context = new FudbalskiTurnirContainer())
                {
                    Igrac igracForChange = _context.Ucesniks_Igrac.Where(x => x.JMBG == igrac.JMBG).FirstOrDefault();

                    igracForChange.BrojGolova = igrac.BrojGolova;
                    igracForChange.DatumRodjenja = igrac.DatumRodjenja;
                    igracForChange.Drzava = igrac.Drzava;
                    igracForChange.Ime = igrac.Ime;
                    igracForChange.Pozicija = igrac.Pozicija;
                    igracForChange.Prezime = igrac.Prezime;
                    igracForChange.Visina = igrac.Visina;
                    igracForChange.Zarada = igrac.Zarada;

                    _context.Entry(igracForChange).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Nije uspela promena igraca");
                throw;
            }
        }

        public BindingList<Contract.Igrac> GetAllIgraci()
        {
            BindingList<Igrac> Igraci = new BindingList<Igrac>();

            using (FudbalskiTurnirContainer _context = new FudbalskiTurnirContainer())
            {
                var IgraciAll = _context.Ucesniks_Igrac;

                foreach (var item in IgraciAll)
                {
                    Igraci.Add(item);
                }
            }
            return Igraci;
        }
    }
}
