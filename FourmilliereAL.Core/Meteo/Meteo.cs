﻿using System;
using System.Collections.ObjectModel;

namespace FourmilliereAL.Core
{
    public class Meteo : IObservable
    {
        private readonly ObservableCollection <Fourmi> observateurList;

        public MeteoType Etat { get; set; }

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
