using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace FourmilliereAL.Core
{
    public class Fourmi : INotifyPropertyChanged
    {
        private PlateauManager plateauManager;
        private Attitude comportement { get; set; }
        private Deplacement deplacement { get; set; }

        protected static Random Hasard = new Random();
        public string Nom { get; set; }
        private int vie;
        public int Vie
        {
            get => vie;
            set
            {
                vie = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Etape> ListEtape { get; set; }
        public Location Position { get; set; }
        public Attitude Comportement
        {
            get
            {
                return comportement;
            }
            set
            {
                comportement = value;
                OnPropertyChanged();
            }
        }
        public Deplacement Deplacement
        {
            get => deplacement;
            set => deplacement = value;
        }

        public Fourmi()
        {
            this.Nom = "";
            this.vie = ConfigFourmi.VIE_FOURMI;
            ListEtape = new ObservableCollection<Etape>();
            Position = new Location(ConfigFourmi.FOURMILIERE_POSITION_X, ConfigFourmi.FOURMILIERE_POSITION_Y);
            plateauManager = PlateauManager.Instance;
            comportement = FabriqueSimulation.CreerFabrique("FabriqueAttitude").CreerAttitude("AttitudeAucune");
            Deplacement = FabriqueSimulation.CreerFabrique("FabriqueDeplacement").CreerDeplacement("AvanceHazard");
            int nbEtapes = 0;
            for (int i = 0; i < nbEtapes; i++)
            {
                ListEtape.Add(new Etape());
            }
        }

        public void ExecuterComportement()
        {
            Comportement.ExecuteFourmi(this);
        }

        public Fourmi(string v, int x, int y)
        {
            this.Nom = v;
            this.vie = ConfigFourmi.VIE_FOURMI;
            ListEtape = new ObservableCollection<Etape>();
            Position = new Location(x, y);
            plateauManager = PlateauManager.Instance;
            Comportement = FabriqueSimulation.CreerFabrique("FabriqueAttitude").CreerAttitude("AttitudeAucune");
            Deplacement = FabriqueSimulation.CreerFabrique("FabriqueDeplacement").CreerDeplacement("AvanceHazard");

            int nbEtapes = 0;
            
            for(int i = 0; i < nbEtapes; i++)
            {
                ListEtape.Add(new Etape());
            }
        }

        public override string ToString()
        {
            return this.Nom;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void MisAjour()
        {
            if (Environnement.Instance.Meteo.Etat == MeteoType.Nuit)
            {
                Deplacement = FabriqueSimulation.CreerFabrique("FabriqueDeplacement").CreerDeplacement("CourtChemin");
                Deplacement.Avance(this, new Location(ConfigFourmi.FOURMILIERE_POSITION_X, ConfigFourmi.FOURMILIERE_POSITION_Y));

            }
            Deplacement = FabriqueSimulation.CreerFabrique("FabriqueDeplacement").CreerDeplacement("AvanceHazard");
            Deplacement.Avance(this);
        }
    }
}