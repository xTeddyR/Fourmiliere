using System;
using System.Collections.ObjectModel;

namespace FourmilliereAL.Core
{
    public class Meteo : AbstractMeteo, IObservable
    {
        private readonly ObservableCollection <Fourmi> observateurList;

        private MeteoType etat;

        public MeteoType Etat
        {
            get
            {
                return etat;
            }
            set
            {
                etat = value;
                this.OnPropertyChanged();
            }
        }

        public Meteo(ref ObservableCollection<Fourmi> List)
        {
            this.Etat = MeteoType.Jour;
            observateurList = List;
        }

        public void Attach(Fourmi observer)
        {
            observateurList.Add(observer);
        }

        public void Detach(Fourmi observer)
        {
            observateurList.Remove(observer);
        }

        public void DisplayObservator()
        {
            foreach (Fourmi o in observateurList)
            {
                Console.WriteLine(o.Nom);
            }
        }

        public void Notify()
        {
            foreach (Fourmi o in observateurList)
            {
                o.MisAjour();
            }
        }
    }
}
