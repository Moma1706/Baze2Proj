using Baze2Proj.Repo;
using Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Baze2Proj.ViewModel
{
    public class StatistikaViewModel : BindableBase   
    {
        private bool isVisibleModifikuj;
        private bool isVisibleObrisi;
        private bool isVisibleDodaj;
        private bool isVisibleStek;

        private Statistika statistika;
        private Statistika selectedStatistika;
        private Statistika statistikaMD;
        private BindingList<Statistika> statistike;

        private StatistikaRepo _repo;

        public ICommand NavCommand { get; private set; }
        public ICommand DodajCommand { get; private set; }
        public ICommand ModifikujCommand { get; private set; }
        public ICommand ObrisiCommand { get; private set; }
        public bool IsVisibleModifikuj { get => isVisibleModifikuj; set { isVisibleModifikuj = value; OnPropertyChanged("IsVisibleModifikuj"); } }
        public bool IsVisibleObrisi { get => isVisibleObrisi; set { isVisibleObrisi = value; OnPropertyChanged("IsVisibleObrisi"); } }
        public bool IsVisibleDodaj { get => isVisibleDodaj; set { isVisibleDodaj = value; OnPropertyChanged("IsVisibleDodaj"); } }
        public bool IsVisibleStek { get => isVisibleStek; set { isVisibleStek = value; OnPropertyChanged("IsVisibleStek"); } }
        public Statistika Statistika { get => statistika; set { statistika = value; OnPropertyChanged("StatistikaMD"); } }
        public Statistika SelectedStatisitka { get => selectedStatistika; set { selectedStatistika = value; OnPropertyChanged("StatistikaMD"); } }
        public Statistika StatisitkaMD { get => statistikaMD; set { statistikaMD = value; OnPropertyChanged("StatistikaMD"); } }
        public BindingList<Statistika> Statistike { get => statistike; set { statistike = value; OnPropertyChanged("Statistike"); } }
       
        public StatistikaViewModel()
        {
            _repo = new StatistikaRepo();
            IsVisibleModifikuj = false;
            IsVisibleDodaj = false;
            IsVisibleObrisi = false;
            IsVisibleStek = false;

            NavCommand = new MyICommand<string>(OnNav);
            DodajCommand = new MyICommand(OnDodaj);
            ModifikujCommand = new MyICommand(OnModifikuj);
            ObrisiCommand = new MyICommand(OnObrisi);

            Statistika = new Statistika();
            SelectedStatisitka = new Statistika();
            StatisitkaMD = new Statistika();
            Statistike = GetAllStatistike();
        }

        public void OnNav(object show)
        {

            string showView1 = (string)show;
            switch (showView1)
            {
                case "dodaj":
                    IsVisibleDodaj = true;
                    IsVisibleModifikuj = false;
                    IsVisibleObrisi = false;
                    IsVisibleStek = true;
                    Statistika = new Statistika();
                    break;
                case "obrisi":
                    IsVisibleDodaj = false;
                    IsVisibleModifikuj = false;
                    IsVisibleObrisi = true;
                    IsVisibleStek = false;
                    StatisitkaMD = SelectedStatisitka;
                    break;
                case "modifikuj":
                    IsVisibleDodaj = false;
                    IsVisibleModifikuj = true;
                    IsVisibleObrisi = false;
                    IsVisibleStek = true;
                    StatisitkaMD = SelectedStatisitka;
                    if (StatisitkaMD == null)
                    {
                        StatisitkaMD = new Statistika();
                    }

                    break;
            }
        }
        public BindingList<Statistika> GetAllStatistike()
        {
            BindingList<Statistika> Statistikae = _repo.GetAllStatistike();

            return Statistikae;
        }
        public void OnDodaj()
        {
            _repo.AddStatistika(StatisitkaMD);

            StatisitkaMD = new Statistika();
            Statistike = GetAllStatistike();

        }
        public void OnModifikuj()
        {
            _repo.EditStatistika(StatisitkaMD);
            StatisitkaMD = new Statistika();
            Statistike = GetAllStatistike();
        }
        public void OnObrisi()
        {

            _repo.DeleteStatistika(StatisitkaMD.IdStatistike);

            StatisitkaMD = new Statistika();
            Statistike = GetAllStatistike();

        }
    }
}
