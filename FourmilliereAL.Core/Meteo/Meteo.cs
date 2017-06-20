using System.Collections.ObjectModel;

namespace FourmilliereAL
{
    class Meteo : IObservable
    {
        private readonly ObservableCollection <Fourmi> observateurList = new ObservableCollection<Fourmi>();

        public MeteoType Etat = MeteoType.Jour;

        public void Attach(Fourmi observer)
        {
            observateurList.Add(observer);
        }

        public void Detach(Fourmi observer)
        {
            observateurList.Remove(observer);
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
