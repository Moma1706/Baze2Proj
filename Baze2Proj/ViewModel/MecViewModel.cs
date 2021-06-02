using Baze2Proj.Repo;
using Contract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private Dictionary<string, bool> turniriBool = new Dictionary<string, bool>();
        private Dictionary<string, bool> sudijeBool = new Dictionary<string, bool>();
        private Dictionary<string, bool> tereniBool = new Dictionary<string, bool>();
        private Dictionary<string, bool> statistikeBool = new Dictionary<string, bool>();

        private Sudija _selectedSudija;
        private ObservableCollection<Sudija> _listSudije = new ObservableCollection<Sudija>();


        private MecRepo _repo;

        private ICommand checkedCommand;
        private ICommand uncheckedCommand;

        private ICommand checkedCommandTurnir;
        private ICommand uncheckedCommandTurnir;

        private ICommand checkedCommandTeren;
        private ICommand uncheckedCommandTerenr;

        private ICommand checkedCommandStatistika;
        private ICommand uncheckedCommandStatistika;


        public ICommand NavCommand { get; private set; }
        public ICommand DodajCommand { get; private set; }
        public ICommand ModifikujCommand { get; private set; }
        public ICommand ObrisiCommand { get; private set; }

        public ICommand CheckedCommand => checkedCommand ?? (checkedCommand = new MyICommand<KeyValuePair<string, bool>>(CheckedCommandExecute));
        public ICommand UncheckedCommand => uncheckedCommand ?? (uncheckedCommand = new MyICommand<KeyValuePair<string, bool>>(UncheckedCommandExecute));

        public ICommand CheckedCommandTurnir => checkedCommandTurnir ?? (checkedCommandTurnir = new MyICommand<KeyValuePair<string, bool>>(CheckedCommandTurnirExecute));
        public ICommand UncheckedCommandTurnir => uncheckedCommandTurnir ?? (uncheckedCommandTurnir = new MyICommand<KeyValuePair<string, bool>>(UncheckedCommandTurnirExecute));

        public ICommand CheckedCommandTeren => checkedCommandTeren ?? (checkedCommandTeren = new MyICommand<KeyValuePair<string, bool>>(CheckedCommandTerenExecute));
        public ICommand UncheckedCommandTeren => uncheckedCommandTerenr ?? (uncheckedCommandTerenr = new MyICommand<KeyValuePair<string, bool>>(UncheckedCommandTerenExecute));

        public ICommand CheckedCommandStatistika => checkedCommandStatistika ?? (checkedCommandStatistika = new MyICommand<KeyValuePair<string, bool>>(CheckedCommandStatistikaExecute));
        public ICommand UncheckedCommandStatistika => uncheckedCommandStatistika ?? (uncheckedCommandStatistika = new MyICommand<KeyValuePair<string, bool>>(UncheckedCommandStatistikaExecute));


        public bool IsVisibleModifikuj { get => isVisibleModifikuj; set { isVisibleModifikuj = value; OnPropertyChanged("IsVisibleModifikuj"); } }
        public bool IsVisibleObrisi { get => isVisibleObrisi; set { isVisibleObrisi = value; OnPropertyChanged("IsVisibleObrisi"); } }
        public bool IsVisibleDodaj { get => isVisibleDodaj; set { isVisibleDodaj = value; OnPropertyChanged("IsVisibleDodaj"); } }
        public bool IsVisibleStek { get => isVisibleStek; set { isVisibleStek = value; OnPropertyChanged("IsVisibleStek"); } }
        public Mec Mec { get => mec; set { mec = value; OnPropertyChanged("MecMD"); } }
        public Mec SelectedMec { get => selectedMec; set { selectedMec = value; OnPropertyChanged("MecMD"); } }
        public Mec MecMD { get => mecMD; set { mecMD = value; OnPropertyChanged("MecMD"); } }
        public BindingList<Mec> Mecevi { get => mecevi; set { mecevi = value; OnPropertyChanged("Mecevi"); } }
        public Dictionary<string, bool> SudijeBool { get => sudijeBool; set => sudijeBool = value; }
        public Dictionary<string, bool> TurniriBool { get => turniriBool; set => turniriBool = value; }
        public Dictionary<string, bool> TereniBool { get => tereniBool; set => tereniBool = value; }
        public Dictionary<string, bool> StatistikeBool { get => statistikeBool; set => statistikeBool = value; }
        public Sudija SelectedSudija { get => _selectedSudija; set => _selectedSudija = value; }
        public ObservableCollection<Sudija> ListSudije { get => _listSudije; set => _listSudije = value; }

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
            //foreach (var item in SudijeBool)
            //{
            //    if(item.Value == true)
            //    {
            //        Sudija sudija = _repo.GetSudija(item.Key);
            //        MecMD.SePrijavljujeSudijaJMBG = sudija.JMBG;
            //    }
            //}

            MecMD.SePrijavljujeSudijaJMBG = SelectedSudija.JMBG;

            foreach (var item in TurniriBool)
            {
                if (item.Value == true)
                {
                    Turnir turnir = _repo.GetTurnir(item.Key);
                    MecMD.SePrijavljujeTurnirIdTurnira = turnir.IdTurnira;
                }
            }

            foreach (var item in TereniBool)
            {
                if (item.Value == true)
                {
                    Teren teren = _repo.GetTeren(item.Key);
                    MecMD.TerenIdTerena = teren.IdTerena;
                }
            }

            foreach (var item in StatistikeBool)
            {
                if (item.Value == true)
                {
                    MecMD.StatistikaIdStatistike = Int32.Parse(item.Key);
                }
            }

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
                    SetSudije();
                    SetTurniri();
                    SetTereni();
                    SetSatitstike();
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

        private void SetSudije()
        {
            SudijeBool.Clear();
            ListSudije.Clear();
            var Sudije = _repo.GetAllSudije();
            
            foreach (var item in Sudije)
            {
                SudijeBool.Add(item.Ime, false);
                ListSudije.Add(item);
            }
        }

        private void SetTurniri()
        {
            TurniriBool.Clear();

            var Turniri = _repo.GetAllTurniri();
            foreach (var item in Turniri)
            {
                TurniriBool.Add(item.Naziv, false);
            }
        }

        private void SetTereni()
        {
            TereniBool.Clear();

            var Tereni = _repo.GetAllTereni();
            foreach (var item in Tereni)
            {
                TereniBool.Add(item.Naziv, false);
            }
        }

        private void SetSatitstike()
        {
            StatistikeBool.Clear();

            var Statistike = _repo.GetAllStatistike();
            foreach (var item in Statistike)
            {
                StatistikeBool.Add(item.IdStatistike.ToString(), false);
            }
        }


        private void CheckedCommandExecute(KeyValuePair<string, bool> name)
        {
            SudijeBool[name.Key] = true;
            OnPropertyChanged("SudijeBool");
        }
        private void UncheckedCommandExecute(KeyValuePair<string, bool> name)
        {
            SudijeBool[name.Key] = false;
            OnPropertyChanged("SudijeBool");
        }


        private void CheckedCommandTurnirExecute(KeyValuePair<string, bool> name)
        {
            TurniriBool[name.Key] = true;
            OnPropertyChanged("TurniriBool");
        }
        private void UncheckedCommandTurnirExecute(KeyValuePair<string, bool> name)
        {
            TurniriBool[name.Key] = false;
            OnPropertyChanged("TurniriBool");
        }

        private void CheckedCommandTerenExecute(KeyValuePair<string, bool> name)
        {
            TereniBool[name.Key] = true;
            OnPropertyChanged("TereniBool");
        }
        private void UncheckedCommandTerenExecute(KeyValuePair<string, bool> name)
        {
            TereniBool[name.Key] = false;
            OnPropertyChanged("TereniBool");
        }

        private void CheckedCommandStatistikaExecute(KeyValuePair<string, bool> name)
        {
            StatistikeBool[name.Key] = true;
            OnPropertyChanged("StatistikeBool");
        }
        private void UncheckedCommandStatistikaExecute(KeyValuePair<string, bool> name)
        {
            StatistikeBool[name.Key] = false;
            OnPropertyChanged("StatistikeBool");
        }
    }
}
