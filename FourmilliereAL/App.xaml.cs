using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Data;
using FourmilliereAL.Core;

namespace FourmilliereAL
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    
    public partial class App : Application
    {
        public static FourmilliereModel fourmilliereVM { get; set; }
        private static object _lock = new object(); 
        public App()
        {
            ObservableCollection<Fourmi> FourmisList = new ObservableCollection<Fourmi>();

            // Synchronisation de la liste entre Thread
            BindingOperations.EnableCollectionSynchronization(FourmisList, _lock);
            fourmilliereVM = new FourmilliereModel(FourmisList);
        }
      
    }
}
