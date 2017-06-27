using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Data;
using FourmilliereAL.Core;
using System.Threading;

namespace FourmilliereAL
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    
    public partial class App : Application
    {
        public static FourmilliereModel fourmilliereVM { get; set; }
        public static PlateauManager PlateauManager { get; set; }
        public static ThreadManager ThreadManager { get; set; }

        public static GrilleManager GrilleManager { get; set; }

        private static object _lock = new object(); 
        public App()
        {
            ObservableCollection<Fourmi> FourmisList = new ObservableCollection<Fourmi>();
            
            // Synchronisation de la liste entre Thread
            BindingOperations.EnableCollectionSynchronization(FourmisList, _lock);
            fourmilliereVM = new FourmilliereModel(FourmisList);
            PlateauManager = PlateauManager.Instance;
            ThreadManager = new ThreadManager();
            GrilleManager = new GrilleManager();

        }
      
    }
}
