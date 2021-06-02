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
    public class MecViewModel : BindableBase
    {
        private bool isVisibleModifikuj;
        private bool isVisibleObrisi;
        private bool isVisibleDodaj;
        private bool isVisibleStek;

        private Mec mec;
        private Mec selectedMec;
        private Mec mecMD;
        private BindingList<Mec> mecevi;

        private MecRepo _repo;

        public ICommand NavCommand { get; private set; }
        public ICommand DodajCommand { get; private set; }
        public ICommand ModifikujCommand { get; private set; }
        public ICommand ObrisiCommand { get; private set; }
        public bool IsVisibleModifikuj { get => isVisibleModifikuj; set { isVisibleModifikuj = value; OnPropertyChanged("IsVisibleModifikuj"); } }
        public bool IsVisibleObrisi { get => isVisibleObrisi; set { isVisibleObrisi = value; OnPropertyChanged("IsVisibleObrisi"); } }
        public bool IsVisibleDodaj { get => isVisibleDodaj; set { isVisibleDodaj = value; OnPropertyChanged("IsVisibleDodaj"); } }
        public bool IsVisibleStek { get => isVisibleStek; set { isVisibleStek = value; OnPropertyChanged("IsVisibleStek"); } }
        public Mec Mec { get => mec; set { mec = value; OnPropertyChanged("MecMD"); } }
        public Mec SelectedMec { get => selectedMec; set { selectedMec = value; OnPropertyChanged("MecMD"); } }
        public Mec MecMD { get => mecMD; set { mecMD = value; OnPropertyChanged("MecMD"); } }
        public BindingList<Mec> Mecevi { get => mecevi; set { mecevi = value; OnPropertyChanged("Mecevi"); } }

        public MecViewModel()
        {
            _repo = new MecRepo();
            IsVisibleModifikuj = false;
            IsVisibleDodaj = false;
            IsVisibleObrisi = false;
            IsVisibleStek = false;

            NavCommand = new MyICommand<string>(OnNav);
            DodajCommand = new MyICommand(OnDodaj);
            ModifikujCommand = new MyICommand(OnModifikuj);
            ObrisiCommand = new MyICommand(OnObrisi);

            Mec = new Mec();
            SelectedMec = new Mec();
            MecMD = new Mec();
            Mecevi = GetAllMecevi();
        }
        public void OnDodaj()
        {
            _repo.AddMec(MecMD);

            MecMD = new Mec();
            Mecevi = GetAllMecevi();

        }
        public void OnModifikuj()
        {
            _repo.EditMec(MecMD);
            MecMD = new Mec();
            Mecevi = GetAllMecevi();
        }
        public void OnObrisi()
        {

            _repo.DeleteMec(MecMD.IdMeca);

            MecMD = new Mec();
            Mecevi = GetAllMecevi();
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
                    Mec = new Mec();
                    break;
                case "obrisi":
                    IsVisibleDodaj = false;
                    IsVisibleModifikuj = false;
                    IsVisibleObrisi = true;
                    IsVisibleStek = false;
                    MecMD = SelectedMec;
                    break;
                case "modifikuj":
                    IsVisibleDodaj = false;
                    IsVisibleModifikuj = true;
                    IsVisibleObrisi = false;
                    IsVisibleStek = true;
                    MecMD = SelectedMec;
                    if (MecMD == null)
                    {
                        MecMD = new Mec();
                    }

                    break;
            }
        }


        public BindingList<Mec> GetAllMecevi()
        {
            BindingList<Mec> Mecevi = _repo.GetAllMecevi();

            return Mecevi;
        }
    }
}
