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
    public class SponzorViewModel : BindableBase
    {
        private bool isVisibleModifikuj;
        private bool isVisibleObrisi;
        private bool isVisibleDodaj;
        private bool isVisibleStek;

        private Sponzor sponzor;
        private Sponzor selectedSponzor;
        private Sponzor sponzorMD;
        private BindingList<Sponzor> sponzori;

        private SponzorRepo _repo;

        public ICommand NavCommand { get; private set; }
        public ICommand DodajCommand { get; private set; }
        public ICommand ModifikujCommand { get; private set; }
        public ICommand ObrisiCommand { get; private set; }
        public bool IsVisibleModifikuj { get => isVisibleModifikuj; set { isVisibleModifikuj = value; OnPropertyChanged("IsVisibleModifikuj"); } }
        public bool IsVisibleObrisi { get => isVisibleObrisi; set { isVisibleObrisi = value; OnPropertyChanged("IsVisibleObrisi"); } }
        public bool IsVisibleDodaj { get => isVisibleDodaj; set { isVisibleDodaj = value; OnPropertyChanged("IsVisibleDodaj"); } }
        public bool IsVisibleStek { get => isVisibleStek; set { isVisibleStek = value; OnPropertyChanged("IsVisibleStek"); } }
        public Sponzor Sponzor { get => sponzor; set { sponzor = value; OnPropertyChanged("SponzorMD"); } }
        public Sponzor SelectedSponzor { get => selectedSponzor; set { selectedSponzor = value; OnPropertyChanged("SponzorMD"); } }
        public Sponzor SponzorMD { get => sponzorMD; set { sponzorMD = value; OnPropertyChanged("SponzorMD"); } }
        public BindingList<Sponzor> Sponzori { get => sponzori; set { sponzori = value; OnPropertyChanged("Sponzori"); } }

        public SponzorViewModel()
        {
            _repo = new SponzorRepo();
            IsVisibleModifikuj = false;
            IsVisibleDodaj = false;
            IsVisibleObrisi = false;
            IsVisibleStek = false;

            NavCommand = new MyICommand<string>(OnNav);
            DodajCommand = new MyICommand(OnDodaj);
            ModifikujCommand = new MyICommand(OnModifikuj);
            ObrisiCommand = new MyICommand(OnObrisi);

            Sponzor = new Sponzor();
            SelectedSponzor = new Sponzor();
            SponzorMD = new Sponzor();
            Sponzori = GetAllSponzori();
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
                    Sponzor = new Sponzor();
                    break;
                case "obrisi":
                    IsVisibleDodaj = false;
                    IsVisibleModifikuj = false;
                    IsVisibleObrisi = true;
                    IsVisibleStek = false;
                    SponzorMD = SelectedSponzor;
                    break;
                case "modifikuj":
                    IsVisibleDodaj = false;
                    IsVisibleModifikuj = true;
                    IsVisibleObrisi = false;
                    IsVisibleStek = true;
                    SponzorMD = SelectedSponzor;
                    if (SponzorMD == null)
                    {
                        SponzorMD = new Sponzor();
                    }
                    break;
            }
        }
        public void OnDodaj()
        {
            _repo.AddSponzor(SponzorMD);

            SponzorMD = new Sponzor();
            Sponzori = GetAllSponzori();

        }
        public void OnModifikuj()
        {
            _repo.EditSponzor(SponzorMD);
            SponzorMD = new Sponzor();
            Sponzori = GetAllSponzori();
        }
        public void OnObrisi()
        {

            _repo.DeleteSponzor(SponzorMD.IdSponzora);

            SponzorMD = new Sponzor();
            Sponzori = GetAllSponzori();

        }
        public BindingList<Sponzor> GetAllSponzori()
        {
            BindingList<Sponzor> Sponzori = _repo.GetAllSponzori();

            return Sponzori;
        }
    }
}
