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
    public class SponzorRepo : ISponzor
    {
        private FudbalskiTurnirContainer _context;
        public SponzorRepo()
        {
            _context = new FudbalskiTurnirContainer();
        }

        public void AddSponzor(Sponzor sponzor)
        {
            try
            {
                _context.Sponzors.Add(sponzor);
                int success = _context.SaveChanges();

                if (success > 0)
                {
                    MessageBox.Show("Uspesno dodat Sponzor!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Dodavanje Sponzora nije uspelo!");
            }
        }

        public void DeleteSponzor(int id)
        {
            try
            {
                if (id == 0)
                {
                    MessageBox.Show("Nije selektovan igrac!");
                    return;
                }
                
                Sponzor sponzor = _context.Sponzors.Where(x => x.IdSponzora == id).FirstOrDefault();
                var list = _context.Turnirs.Where(x => x.Sponzors.All(y=>y.IdSponzora == sponzor.IdSponzora));
                foreach (var item in list)
                {
                    sponzor.Turnirs.Remove(item);
                }

                _context.Sponzors.Remove(sponzor);
                _context.SaveChanges();
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Nije uspelo brisanje sponzora!");
                throw;
            }
        }

        public void EditSponzor(Sponzor sponzor)
        {
            try
            {
                if (sponzor == null)
                {
                    MessageBox.Show("Nije selektovan Sponzor!");
                    return;
                }

                Sponzor sponzorForChange = _context.Sponzors.FirstOrDefault(x => x.IdSponzora == sponzor.IdSponzora);

                sponzorForChange.CEO = sponzor.CEO;
                sponzorForChange.Naziv = sponzor.Naziv;
                sponzorForChange.Sediste = sponzor.Sediste;
                sponzorForChange.Ulaganje = sponzor.Ulaganje;   

                _context.Entry(sponzorForChange).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Nije uspela promena igraca");
                throw;
            }
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
