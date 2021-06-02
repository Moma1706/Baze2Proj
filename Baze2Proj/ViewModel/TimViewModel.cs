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
    public class TimViewModel : BindableBase
    {
        private bool isVisibleModifikuj;
        private bool isVisibleObrisi;
        private bool isVisibleDodaj;
        private bool isVisibleStek;

        private Tim tim;
        private Tim selectedTim;
        private Tim timMD;
        private BindingList<Tim> timovi;

        private TimRepo _repo;

        public ICommand NavCommand { get; private set; }
        public ICommand DodajCommand { get; private set; }
        public ICommand ModifikujCommand { get; private set; }
        public ICommand ObrisiCommand { get; private set; }

        private ICommand checkedCommand;
        private ICommand uncheckedCommand;

        private ICommand checkedCommandTrener;
        private ICommand uncheckedCommandTrener;

        public bool IsVisibleModifikuj { get => isVisibleModifikuj; set { isVisibleModifikuj = value; OnPropertyChanged("IsVisibleModifikuj"); } }
        public bool IsVisibleObrisi { get => isVisibleObrisi; set { isVisibleObrisi = value; OnPropertyChanged("IsVisibleObrisi"); } }
        public bool IsVisibleDodaj { get => isVisibleDodaj; set { isVisibleDodaj = value; OnPropertyChanged("IsVisibleDodaj"); } }
        public bool IsVisibleStek { get => isVisibleStek; set { isVisibleStek = value; OnPropertyChanged("IsVisibleStek"); } }
        public Tim Tim { get => tim; set { tim = value; OnPropertyChanged("TimMD"); } }
        public Tim SelectedTim { get => selectedTim; set { selectedTim = value; OnPropertyChanged("TimMD"); } }
        public Tim TimMD { get => timMD; set { timMD = value; OnPropertyChanged("TimMD"); } }
        public BindingList<Tim> Timovi { get => timovi; set { timovi = value; OnPropertyChanged("Timovi"); } }
        
        private Dictionary<string, bool> igraciBool = new Dictionary<string, bool>();
        private Dictionary<string, bool> treneriBool = new Dictionary<string, bool>();

        public TimViewModel()
        {
            _repo = new TimRepo();
            IsVisibleModifikuj = false;
            IsVisibleDodaj = false;
            IsVisibleObrisi = false;
            IsVisibleStek = false;

            NavCommand = new MyICommand<string>(OnNav);
            DodajCommand = new MyICommand(OnDodaj);
            ModifikujCommand = new MyICommand(OnModifikuj);
            ObrisiCommand = new MyICommand(OnObrisi);

            Tim = new Tim();
            SelectedTim = new Tim();
            TimMD = new Tim();
            Timovi = GetAllTimovi();
        }
        public void OnDodaj()
        {
            _repo.AddTim(TimMD);

            TimMD = new Tim();
            Timovi = GetAllTimovi();

        }
        public void OnModifikuj()
        {
            _repo.EditTim(TimMD);
            TimMD = new Tim();
            Timovi = GetAllTimovi();
        }
        public void OnObrisi()
        {

            _repo.DeleteTim(TimMD.IdTima);

            TimMD = new Tim();
            Timovi = GetAllTimovi();
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
                    Tim = new Tim();
                    SetIgraci();
                    SetTreneri();
                    break;
                case "obrisi":
                    IsVisibleDodaj = false;
                    IsVisibleModifikuj = false;
                    IsVisibleObrisi = true;
                    IsVisibleStek = false;
                    TimMD = SelectedTim;
                    break;
                case "modifikuj":
                    IsVisibleDodaj = false;
                    IsVisibleModifikuj = true;
                    IsVisibleObrisi = false;
                    IsVisibleStek = true;
                    TimMD = SelectedTim;
                    if (TimMD == null)
                    {
                        TimMD = new Tim();
                    }

                    break;
            }
        }
        public BindingList<Tim> GetAllTimovi()
        {
            BindingList<Tim> Timovi = _repo.GetAllTimovi();

            return Timovi;
        }

        private void SetIgraci()
        {
            IgraciBool.Clear();

            var Igraci = _repo.GetAllIgraci();
            foreach (var item in Igraci)
            {
                IgraciBool.Add(item.Ime, false);
            }
        }

        private void SetTreneri()
        {
            TreneriBool.Clear();

            var Treneri = _repo.GetAllTreneri();
            foreach (var item in Treneri)
            {
                TreneriBool.Add(item.Ime, false);
            }
        }

        public Dictionary<string, bool> IgraciBool { get => igraciBool; set => igraciBool = value; }

        public ICommand CheckedCommand => checkedCommand ?? (checkedCommand = new MyICommand<KeyValuePair<string, bool>>(CheckedCommandExecute));

        public ICommand UncheckedCommand => uncheckedCommand ?? (uncheckedCommand = new MyICommand<KeyValuePair<string, bool>>(UncheckedCommandExecute));

        public ICommand CheckedCommandTrener => checkedCommandTrener ?? (checkedCommandTrener = new MyICommand<KeyValuePair<string, bool>>(CheckedCommandExecuteTrener));

        public ICommand UncheckedCommandTrener => uncheckedCommandTrener ?? (uncheckedCommandTrener = new MyICommand<KeyValuePair<string, bool>>(UncheckedCommandExecuteTrener));

        public Dictionary<string, bool> TreneriBool { get => treneriBool; set => treneriBool = value; }

        private void CheckedCommandExecute(KeyValuePair<string, bool> name)
        {
            IgraciBool[name.Key] = true;
            OnPropertyChanged("IgraciBool");
        }
        private void UncheckedCommandExecute(KeyValuePair<string, bool> name)
        {
            IgraciBool[name.Key] = false;
            OnPropertyChanged("IgraciBool");
        }

        private void CheckedCommandExecuteTrener(KeyValuePair<string, bool> name)
        {
            IgraciBool[name.Key] = true;
            OnPropertyChanged("TreneriBool");
        }
        private void UncheckedCommandExecuteTrener(KeyValuePair<string, bool> name)
        {
            IgraciBool[name.Key] = false;
            OnPropertyChanged("TreneriBool");
        }
    }
}
