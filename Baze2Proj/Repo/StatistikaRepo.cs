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
    public class StatistikaRepo : IStatistika
    {
        private FudbalskiTurnirContainer _context;
        public StatistikaRepo()
        {
            _context = new FudbalskiTurnirContainer();
        }

        public void AddStatistika(Statistika statistika)
        {
            try
            {
                _context.Statistikas.Add(statistika);
                int success = _context.SaveChanges();

                if (success > 0)
                {
                    MessageBox.Show("Uspesno dodata Statisitka!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Dodavanje Statistike nije uspelo!");
            }
        }

        public void DeleteStatistika(int id)
        {
            try
            {
                if (id == null)
                {
                    MessageBox.Show("Nije selektovana Statistika!");
                    return;
                }

                Statistika statistika = _context.Statistikas.FirstOrDefault(x => x.IdStatistike == id);

                _context.Statistikas.Remove(statistika);
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                MessageBox.Show("Nije uspelo brisanje Statistike!");
                throw;
            }
        }

        public void EditStatistika(Statistika statistika)
        {
            try
            {
                if (statistika == null)
                {
                    MessageBox.Show("Nije selektovana Statistika!");
                    return;
                }

                Statistika statistikaForChange = _context.Statistikas.FirstOrDefault(x => x.IdStatistike == statistika.IdStatistike);

                statistikaForChange.Golovi = statistika.Golovi;
                statistikaForChange.Kartoni = statistika.Kartoni;
                statistikaForChange.Asistencije = statistika.Asistencije;

                _context.Entry(statistikaForChange).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                MessageBox.Show("Nije uspela promena Statistike");
                throw;
            }
        }

        public BindingList<Statistika> GetAllStatistike()
        {
            BindingList<Statistika> Statisike = new BindingList<Statistika>();

            var SatistikeAll = _context.Statistikas;

            foreach (var item in SatistikeAll)
            {
                Statisike.Add(item);
            }

            return Statisike;
        }
    }
}
