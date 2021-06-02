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
    public class TerenViewModel : BindableBase 
    {
        private bool isVisibleModifikuj;
        private bool isVisibleObrisi;
        private bool isVisibleDodaj;
        private bool isVisibleStek;

        private Teren teren;
        private Teren selectedTeren;
        private Teren terenMD;
        private BindingList<Teren> tereni;

        private TerenRepo _repo;

        public ICommand NavCommand { get; private set; }
        public ICommand DodajCommand { get; private set; }
        public ICommand ModifikujCommand { get; private set; }
        public ICommand ObrisiCommand { get; private set; }
        public bool IsVisibleModifikuj { get => isVisibleModifikuj; set { isVisibleModifikuj = value; OnPropertyChanged("IsVisibleModifikuj"); } }
        public bool IsVisibleObrisi { get => isVisibleObrisi; set { isVisibleObrisi = value; OnPropertyChanged("IsVisibleObrisi"); } }
        public bool IsVisibleDodaj { get => isVisibleDodaj; set { isVisibleDodaj = value; OnPropertyChanged("IsVisibleDodaj"); } }
        public bool IsVisibleStek { get => isVisibleStek; set { isVisibleStek = value; OnPropertyChanged("IsVisibleStek"); } }
        public Teren Teren { get => teren; set { teren = value; OnPropertyChanged("TerenMD"); } }
        public Teren SelctedTeren { get => selectedTeren; set { selectedTeren = value; OnPropertyChanged("TerenMD"); } }
        public Teren TerenMD { get => terenMD; set { terenMD = value; OnPropertyChanged("TerenMD"); } }
        public BindingList<Teren> Tereni { get => tereni; set { tereni = value; OnPropertyChanged("Tereni"); } }

        public TerenViewModel()
        {
            _repo = new TerenRepo();
            IsVisibleModifikuj = false;
            IsVisibleDodaj = false;
            IsVisibleObrisi = false;
            IsVisibleStek = false;

            NavCommand = new MyICommand<string>(OnNav);
            DodajCommand = new MyICommand(OnDodaj);
            ModifikujCommand = new MyICommand(OnModifikuj);
            ObrisiCommand = new MyICommand(OnObrisi);

            Teren = new Teren();
            SelctedTeren = new Teren();
            TerenMD = new Teren();
            Tereni = GetAllTereni();
        }
        public void OnDodaj()
        {
            _repo.AddTeren(TerenMD);

            TerenMD = new Teren();
            Tereni = GetAllTereni();

        }
        public void OnModifikuj()
        {
            _repo.EditTeren(TerenMD);
            TerenMD = new Teren();
            Tereni = GetAllTereni();
        }
        public void OnObrisi()
        {

            _repo.DeleteTeren(TerenMD.IdTerena);

            TerenMD = new Teren();
            Tereni = GetAllTereni();
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
                    Teren = new Teren();
                    break;
                case "obrisi":
                    IsVisibleDodaj = false;
                    IsVisibleModifikuj = false;
                    IsVisibleObrisi = true;
                    IsVisibleStek = false;
                    TerenMD = SelctedTeren;
                    break;
                case "modifikuj":
                    IsVisibleDodaj = false;
                    IsVisibleModifikuj = true;
                    IsVisibleObrisi = false;
                    IsVisibleStek = true;
                    TerenMD = SelctedTeren;
                    if (TerenMD == null)
                    {
                        TerenMD = new Teren();
                    }

                    break;
            }
        }


        public BindingList<Teren> GetAllTereni()
        {
            BindingList<Teren> Tereni = _repo.GetAllTereni();

            return Tereni;
        }
    }
}
