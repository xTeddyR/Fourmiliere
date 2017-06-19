using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ComponentModel;


namespace FourmilliereAL
{
    public class Fourmi : INotifyPropertyChanged
    {
        private PlateauManager plateauManager;

        protected static Random Hasard = new Random();
        public string Nom { get; set; }
        private int vie;
        public int Vie
        {
            get { return vie; }
            set
            {
                vie = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Etape> ListEtape { get; set; }
        public Location Position { get; set; }
        public Attitude Comportement { get; set; }
        public Deplacement Deplace { get; set; }

        public Fourmi(string v, int x, int y)
        {
            this.Nom = v;
            this.vie = ConfigFourmi.VieFourmi;
            ListEtape = new ObservableCollection<Etape>();
            Position = new Location(x, y);
            plateauManager = PlateauManager.Instance;
            Comportement = new AttitudeAucune();
            Deplace = new AvanceHazard();
            int nbEtapes = Hasard.Next(10);
            for(int i = 0; i < nbEtapes; i++)
            {
                ListEtape.Add(new Etape());
            }
        }
        public virtual void AvanceUnTour(int dimX, int dimY)
        {
            
            Deplace.Avance(this,dimX, dimY);
            ListEtape.Add(new Etape());

            Vie--;

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
    }
}