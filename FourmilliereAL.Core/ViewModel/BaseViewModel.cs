using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FourmilliereAL.Core
{
    /// <summary>
    /// Un ViewModel de base implémentant la notification de changements de propriétés
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// L'event qui est déclenché quand un propriété de la class enfant est modififée
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// appel cet fonction pour déclencher un a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
