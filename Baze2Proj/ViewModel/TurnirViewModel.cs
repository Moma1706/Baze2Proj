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
    public class TurnirViewModel : BindableBase 
    {
        private bool isVisibleModifikuj;
        private bool isVisibleObrisi;
        private bool isVisibleDodaj;
        private bool isVisibleStek;

        private Turnir turnir;
        private Turnir selectedTurnir;
        private Turnir turnirMD;
        private BindingList<Turnir> turniri;
        private List<string> tipTurnira;

        private TurnirRepo _repo;
        public ICommand NavCommand { get; private set; }
        public ICommand DodajCommand { get; private set; }
        public ICommand ModifikujCommand { get; private set; }
        public ICommand ObrisiCommand { get; private set; }

        private ICommand checkedCommand;
        private ICommand uncheckedCommand;

        public bool IsVisibleModifikuj { get => isVisibleModifikuj; set { isVisibleModifikuj = value; OnPropertyChanged("IsVisibleModifikuj"); } }
        public bool IsVisibleObrisi { get => isVisibleObrisi; set { isVisibleObrisi = value; OnPropertyChanged("IsVisibleObrisi"); } }
        public bool IsVisibleDodaj { get => isVisibleDodaj; set { isVisibleDodaj = value; OnPropertyChanged("IsVisibleDodaj"); } }
        public bool IsVisibleStek { get => isVisibleStek; set { isVisibleStek = value; OnPropertyChanged("IsVisibleStek"); } }
        public Turnir Turnir { get => turnir; set { turnir = value; OnPropertyChanged("TurnirMD"); } }
        public Turnir SelectedTurnir { get => selectedTurnir; set { selectedTurnir = value; OnPropertyChanged("TurnirMD"); } }
        public Turnir TurnirMD { get => turnirMD; set { turnirMD = value; OnPropertyChanged("TreTurnirMDnerMD"); } }
        public BindingList<Turnir> Turniri { get => turniri; set { turniri = value; OnPropertyChanged("Turniri"); } }

        private Dictionary<string, bool> sponzorBool = new Dictionary<string, bool>();
        public List<string> TipTurnira { get => tipTurnira; set => tipTurnira = value; }


        public TurnirViewModel()
        {
            _repo = new TurnirRepo();
            IsVisibleModifikuj = false;
            IsVisibleDodaj = false;
            IsVisibleObrisi = false;
            IsVisibleStek = false;

            TipTurnira = new List<string>();
            TipTurnira.Add("Drzava");
            TipTurnira.Add("Klub");

            NavCommand = new MyICommand<string>(OnNav);
            DodajCommand = new MyICommand(OnDodaj);
            ModifikujCommand = new MyICommand(OnModifikuj);
            ObrisiCommand = new MyICommand(OnObrisi);

            Turnir = new Turnir();
            SelectedTurnir = new Turnir();
            TurnirMD = new Turnir();
            Turniri = GetAllTurniri();

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
                    Turnir = new Turnir();
                    SetSponzors();
                    break;
                case "obrisi":
                    IsVisibleDodaj = false;
                    IsVisibleModifikuj = false;
                    IsVisibleObrisi = true;
                    IsVisibleStek = false;
                    TurnirMD = SelectedTurnir;
                    break;
                case "modifikuj":
                    IsVisibleDodaj = false;
                    IsVisibleModifikuj = true;
                    IsVisibleObrisi = false;
                    IsVisibleStek = true;
                    TurnirMD = SelectedTurnir;
                    if (TurnirMD == null)
                    {
                        TurnirMD = new Turnir();
                    }

                    break;
            }
        }

        private void SetSponzors()
        {
            SponzoriBool.Clear();

            var sponzori = _repo.GetAllSponzori();
            foreach (var item in sponzori)
                SponzoriBool.Add(item.Naziv, false);
        }

        public BindingList<Turnir> GetAllTurniri()
        {
            BindingList<Turnir> Turniri = _repo.GetAllTurniri();

            return Turniri;
        }

        public void OnDodaj()
        {
            foreach (var item in SponzoriBool)
            {
                if (item.Value)
                {
                    var spozor = _repo.GetAllSponzori().FirstOrDefault(x => x.Naziv == item.Key);
                    turnirMD.Sponzors.Add(spozor);
                }
            }

            _repo.AddTurnir(TurnirMD);

            TurnirMD = new Turnir();
            Turniri = GetAllTurniri();

        }
        public void OnModifikuj()
        {
            _repo.EditTurnir(TurnirMD);
            TurnirMD = new Turnir();
            Turniri = GetAllTurniri();
        }
        public void OnObrisi()
        {

            _repo.DeleteTurnir(TurnirMD.IdTurnira);

            TurnirMD = new Turnir();
            Turniri = GetAllTurniri(); ;

        }

        #region Sponzors
        public Dictionary<string, bool> SponzoriBool { get => sponzorBool; set => sponzorBool = value; }

        public ICommand CheckedCommand => checkedCommand ?? (checkedCommand = new MyICommand<KeyValuePair<string, bool>>(CheckedCommandExecute));

        public ICommand UncheckedCommand => uncheckedCommand ?? (uncheckedCommand = new MyICommand<KeyValuePair<string, bool>>(UncheckedCommandExecute));


        private void CheckedCommandExecute(KeyValuePair<string, bool> name)
        {
            SponzoriBool[name.Key] = true;
            OnPropertyChanged("SponzoriBool");
        }
        private void UncheckedCommandExecute(KeyValuePair<string, bool> name)
        {
            SponzoriBool[name.Key] = false;
            OnPropertyChanged("SponzoriBool");
        }

        #endregion
    }
}
