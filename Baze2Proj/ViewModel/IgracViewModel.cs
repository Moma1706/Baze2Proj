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
    public class IgracViewModel : BindableBase
    {
        private bool isVisibleModifikuj;
        private bool isVisibleObrisi;
        private bool isVisibleDodaj;
        private bool isVisibleStek;

        private Igrac igrac;
        private Igrac selectedIgrac;
        private Igrac igracMD;
        private BindingList<Igrac> igraci;

        private IgracRepo _repo;

        public ICommand NavCommand { get; private set; }
        public ICommand DodajCommand { get; private set; }
        public ICommand ModifikujCommand { get; private set; }
        public ICommand ObrisiCommand { get; private set; }

        public IgracViewModel()
        {
            _repo = new IgracRepo();
            IsVisibleModifikuj = false;
            IsVisibleDodaj = false;
            IsVisibleObrisi = false;
            IsVisibleStek = false;

            NavCommand = new MyICommand<string>(OnNav);
            DodajCommand = new MyICommand(OnDodaj);
            ModifikujCommand = new MyICommand(OnModifikuj);
            ObrisiCommand = new MyICommand(OnObrisi);

            Igrac = new Igrac();
            SelectedIgrac = new Igrac();
            IgracMD = new Igrac();
            Igraci = GetAllIgraci();
        }

        public void OnDodaj() 
        {
            _repo.AddIgrac(IgracMD);

            IgracMD = new Igrac();
            Igraci = GetAllIgraci();

        } 
        public void OnModifikuj() 
        {
            _repo.EditIgrac(igracMD);
            IgracMD = new Igrac();
            Igraci = GetAllIgraci();
        }
        public void OnObrisi() {

            _repo.DeleteIgrac(igracMD.JMBG);

            IgracMD = new Igrac();
            Igraci = GetAllIgraci();
        }
        

        #region Property
        public Igrac Igrac
        {
            get { return igrac; }
            set
            {

                if (value != igrac)
                {
                    igrac = value;
                    OnPropertyChanged("IgracMD");
                }
            }

        }

        public Igrac IgracMD
        {
            get { return igracMD; }
            set
            {

                if (value != igracMD)
                {
                    igracMD = value;
                    OnPropertyChanged("IgracMD");
                }
            }
        }

        public Igrac SelectedIgrac
        {
            get { return selectedIgrac; }
            set
            {

                if (value != selectedIgrac)
                {
                    selectedIgrac = value;
                    OnPropertyChanged("IgracMD");
                    if (IsVisibleModifikuj == true)
                    {
                        Igrac = SelectedIgrac;
                        if (Igrac != null)
                        {
                            Igrac = GetAllIgraci().Where(x => x.JMBG == Igrac.JMBG).FirstOrDefault();
                        }
                        else
                        {
                            Igrac = new Igrac();
                        }
                    }
                }
            }
        }

        public BindingList<Igrac> Igraci
        {
            get { return igraci; }
            set
            {

                if (value != igraci)
                {
                    igraci = value;
                    OnPropertyChanged("Igraci");
                }
            }
        }

        public bool IsVisibleDodaj
        {
            get { return isVisibleDodaj; }
            set
            {
                isVisibleDodaj = value;
                OnPropertyChanged("IsVisibleDodaj");
            }
        }
        public bool IsVisibleStek
        {
            get { return isVisibleStek; }
            set
            {
                isVisibleStek = value;
                OnPropertyChanged("IsVisibleStek");
            }
        }
        public bool IsVisibleObrisi
        {
            get { return isVisibleObrisi; }
            set
            {
                isVisibleObrisi = value;
                OnPropertyChanged("IsVisibleObrisi");
            }
        }
        public bool IsVisibleModifikuj
        {
            get { return isVisibleModifikuj; }
            set
            {
                isVisibleModifikuj = value;
                OnPropertyChanged("IsVisibleModifikuj");
            }
        }
        #endregion  

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
                    Igrac = new Igrac();
                    break;
                case "obrisi":
                    IsVisibleDodaj = false;
                    IsVisibleModifikuj = false;
                    IsVisibleObrisi = true;
                    IsVisibleStek = false;
                    IgracMD = SelectedIgrac;
                    break;
                case "modifikuj":
                    IsVisibleDodaj = false;
                    IsVisibleModifikuj = true;
                    IsVisibleObrisi = false;
                    IsVisibleStek = true;
                    IgracMD = SelectedIgrac;
                    if(IgracMD == null)
                    {
                        IgracMD = new Igrac();
                    }

                    break;
            }
        }


        public BindingList<Igrac> GetAllIgraci()
        {
            BindingList<Igrac> Igraci = _repo.GetAllIgraci();

            return Igraci;
        }
    }
}
