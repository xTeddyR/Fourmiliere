using System;
using System.Collections.ObjectModel;

namespace FourmilliereAL.Fabriques
{
    public class Fourmi : Creature
    {        
        public Fourmi(string v)
        {
            this.Nom = v;
            this.Vie = 20;
            ListEtape = new ObservableCollection<Etape>();
            X = 10;
            Y = 10;
            int nbEtapes = Hasard.Next(10);
            for(int i = 0; i < nbEtapes; i++)
            {
                ListEtape.Add(new Etape());
            }
        }
        public override string ToString()
        {
            return "Ma fourmis" + this.Nom;
        }
    }
}