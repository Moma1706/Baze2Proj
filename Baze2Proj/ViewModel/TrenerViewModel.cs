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
    public class TrenerViewModel : BindableBase 
    {
        private bool isVisibleModifikuj;
        private bool isVisibleObrisi;
        private bool isVisibleDodaj;
        private bool isVisibleStek;

        private Trener trener;
        private Trener selectedTrener;
        private Trener trenerMD;
        private BindingList<Trener> treneri;

        private TrenerRepo _repo;

        public ICommand NavCommand { get; private set; }
        public ICommand DodajCommand { get; private set; }
        public ICommand ModifikujCommand { get; private set; }
        public ICommand ObrisiCommand { get; private set; }

        public bool IsVisibleModifikuj { get => isVisibleModifikuj; set { isVisibleModifikuj = value; OnPropertyChanged("IsVisibleModifikuj"); } }
        public bool IsVisibleObrisi { get => isVisibleObrisi; set { isVisibleObrisi = value; OnPropertyChanged("IsVisibleObrisi"); } }
        public bool IsVisibleDodaj { get => isVisibleDodaj; set { isVisibleDodaj = value; OnPropertyChanged("IsVisibleDodaj"); } }
        public bool IsVisibleStek { get => isVisibleStek; set { isVisibleStek = value; OnPropertyChanged("IsVisibleStek"); } }
        public Trener Trener { get => trener; set { trener = value; OnPropertyChanged("TrenerMD"); } }
        public Trener SelectedTrener { get => selectedTrener; set { selectedTrener = value; OnPropertyChanged("TrenerMD"); } }
        public Trener TrenerMD { get => trenerMD; set { trenerMD = value; OnPropertyChanged("TrenerMD"); } }
        public BindingList<Trener> Treneri { get => treneri; set { treneri = value; OnPropertyChanged("Treneri"); } }

        public TrenerViewModel()
        {
            _repo = new TrenerRepo();
            IsVisibleModifikuj = false;
            IsVisibleDodaj = false;
            IsVisibleObrisi = false;
            IsVisibleStek = false;

            NavCommand = new MyICommand<string>(OnNav);
            DodajCommand = new MyICommand(OnDodaj);
            ModifikujCommand = new MyICommand(OnModifikuj);
            ObrisiCommand = new MyICommand(OnObrisi);

            Trener = new Trener();
            TrenerMD = new Trener();
            SelectedTrener = new Trener();
            Treneri = GetAllTreneri();

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
                    Trener = new Trener();
                    break;
                case "obrisi":
                    IsVisibleDodaj = false;
                    IsVisibleModifikuj = false;
                    IsVisibleObrisi = true;
                    IsVisibleStek = false;
                    TrenerMD = SelectedTrener;
                    break;
                case "modifikuj":
                    IsVisibleDodaj = false;
                    IsVisibleModifikuj = true;
                    IsVisibleObrisi = false;
                    IsVisibleStek = true;
                    TrenerMD = SelectedTrener;
                    if (TrenerMD == null)
                    {
                        TrenerMD = new Trener();
                    }

                    break;
            }
        }
        public BindingList<Trener> GetAllTreneri()
        {
            BindingList<Trener> Treneri = _repo.GetAllTreneri();

            return Treneri;
        }

        public void OnDodaj()
        {
            _repo.AddTrener(TrenerMD);

            TrenerMD = new Trener();
            Treneri = GetAllTreneri();

        }
        public void OnModifikuj()
        {
            _repo.EditTrener(TrenerMD);
            TrenerMD = new Trener();
            Treneri = GetAllTreneri();
        }
        public void OnObrisi()
        {

            _repo.DeleteTrener(TrenerMD.JMBG);

            TrenerMD = new Trener();
            Treneri = GetAllTreneri(); ;

        }
    }
}
