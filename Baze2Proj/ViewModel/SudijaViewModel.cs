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
    public class SudijaViewModel : BindableBase 
    {
        private bool isVisibleModifikuj;
        private bool isVisibleObrisi;
        private bool isVisibleDodaj;
        private bool isVisibleStek;

        private Sudija sudija;
        private Sudija selectedSudija;
        private Sudija sudijaMD;
        private BindingList<Sudija> sudije;

        private SudijaRepo _repo;

        public ICommand NavCommand { get; private set; }
        public ICommand DodajCommand { get; private set; }
        public ICommand ModifikujCommand { get; private set; }
        public ICommand ObrisiCommand { get; private set; }


        public SudijaViewModel()
        {
            _repo = new SudijaRepo();
            IsVisibleModifikuj = false;
            IsVisibleDodaj = false;
            IsVisibleObrisi = false;
            IsVisibleStek = false;

            NavCommand = new MyICommand<string>(OnNav);
            DodajCommand = new MyICommand(OnDodaj);
            ModifikujCommand = new MyICommand(OnModifikuj);
            ObrisiCommand = new MyICommand(OnObrisi);

            Sudija = new Sudija();
            SelectedSudija = new Sudija();
            SudijaMD = new Sudija();
            Sudije = GetAllSudije();
        }

        public Sudija SelectedSudija { get => selectedSudija; set { selectedSudija = value; OnPropertyChanged("SudijaMD"); } }
        public bool IsVisibleModifikuj { get => isVisibleModifikuj; set { isVisibleModifikuj = value; OnPropertyChanged("IsVisibleModifikuj"); } }
        public bool IsVisibleObrisi { get => isVisibleObrisi; set { isVisibleObrisi = value; OnPropertyChanged("IsVisibleObrisi"); } }
        public bool IsVisibleDodaj { get => isVisibleDodaj; set { isVisibleDodaj = value; OnPropertyChanged("IsVisibleDodaj"); } }
        public bool IsVisibleStek { get => isVisibleStek; set { isVisibleStek = value; OnPropertyChanged("IsVisibleStek"); } }
        public Sudija SudijaMD { get => sudijaMD; set { sudijaMD = value; OnPropertyChanged("SudijaMD"); } }
        public BindingList<Sudija> Sudije { get => sudije; set { sudije = value; OnPropertyChanged("Sudije"); } }
        public Sudija Sudija { get => sudija; set { sudija = value; OnPropertyChanged("SudijaMD"); } }

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
                    Sudija = new Sudija();
                    break;
                case "obrisi":
                    IsVisibleDodaj = false;
                    IsVisibleModifikuj = false;
                    IsVisibleObrisi = true;
                    IsVisibleStek = false;
                    SudijaMD = SelectedSudija;
                    break;
                case "modifikuj":
                    IsVisibleDodaj = false;
                    IsVisibleModifikuj = true;
                    IsVisibleObrisi = false;
                    IsVisibleStek = true;
                    SudijaMD = SelectedSudija;
                    if (SudijaMD == null)
                    {
                        SudijaMD = new Sudija();
                    }

                    break;
            }
        }

        public BindingList<Sudija> GetAllSudije()
        {
            BindingList<Sudija> Sudije = _repo.GetAllSudije();

            return Sudije;
        }

        public void OnDodaj()
        {
            _repo.AddSudija(SudijaMD);

            SudijaMD = new Sudija();
            Sudije = GetAllSudije();

        }
        public void OnModifikuj()
        {
            _repo.EditSudija(SudijaMD);
            SudijaMD = new Sudija();
            Sudije = GetAllSudije();
        }
        public void OnObrisi()
        {

            _repo.DeleteSudija(SudijaMD.JMBG);

            SudijaMD = new Sudija();
            Sudije = GetAllSudije();

        }
    }
}
