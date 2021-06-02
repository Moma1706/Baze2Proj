using Baze2Proj.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baze2Proj
{
    public class MainWindowViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }

        private IgracViewModel igracViewModel = new IgracViewModel();
        private MecViewModel mecViewModel = new MecViewModel();
        private SponzorViewModel sponzorViewModel = new SponzorViewModel();
        private StatistikaViewModel statistikaViewModel = new StatistikaViewModel();
        private SudijaViewModel sudijaViewModel = new SudijaViewModel();
        private TerenViewModel terenViewModel = new TerenViewModel();
        private TimViewModel timViewModel = new TimViewModel();
        private TurnirViewModel turnirViewModel = new TurnirViewModel();
        private TrenerViewModel trenerViewModel = new TrenerViewModel();
        



        private BindableBase currentViewModel;

        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = igracViewModel;
        }

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "igrac":
                    CurrentViewModel = igracViewModel;
                    break;
                case "mec":
                    CurrentViewModel = mecViewModel;
                    break;
                case "sponzor":
                    CurrentViewModel = sponzorViewModel;
                    break;
                case "statistika":
                    CurrentViewModel = statistikaViewModel;
                    break;
                case "sudija":
                    CurrentViewModel = sudijaViewModel;
                    break;
                case "teren":
                    CurrentViewModel = terenViewModel;
                    break;
                case "tim":
                    CurrentViewModel = timViewModel;
                    break;
                case "trener":
                    CurrentViewModel = trenerViewModel;
                    break;
                case "turnir":
                    CurrentViewModel = turnirViewModel;
                    break;
            }
        }
    }
}
