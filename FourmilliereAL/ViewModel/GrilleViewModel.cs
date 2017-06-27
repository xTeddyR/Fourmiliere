using System.Windows;
using System.Windows.Input;
using FourmilliereAL.Core;
using System.Windows.Threading;
using System.Diagnostics;
using System.Globalization;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Linq;
using System.Threading;

namespace FourmilliereAL
{
    class GrilleViewModel : BaseViewModel
    {
        #region Membres publiques
        public DispatcherTimer dt = new DispatcherTimer();
        public Grid Plateau { get; set; }
        #endregion

        #region Commandes
        public ICommand TourSuivantCommande { get; set; }
        public ICommand StopCommande { get; set; }
        public ICommand PlayCommande { get; set; }
        #endregion

        #region Constructeur
        /// <summary>
        /// Le constructeur par défaut
        /// </summary>
        public GrilleViewModel(Grid Grid)
        {
            Plateau = Grid;

            App.GrilleManager.Plateau = Plateau;

            dt.Tick += Redessine_Tick;
            dt.Interval = new TimeSpan(0, 0, 0, 0, App.fourmilliereVM.VitesseExecution);

            PlayCommande = new RelayCommand(() => ExecuterAvance());
            StopCommande = new RelayCommand(() => ExecuterStop());
            TourSuivantCommande = new RelayCommand(() => ExecuterTourSuivant());
        }
        #endregion


        public void Redessine_Tick(object sender, EventArgs e)
        {
            if (App.ThreadManager.StopWatch.IsRunning) {
                App.GrilleManager.Dessine();
            }
        }

        public void ExecuterTourSuivant()
        {
            App.fourmilliereVM.TourSuivant();
            App.GrilleManager.Dessine();
        }

        private void ExecuterAvance()
        {

            dt.Start();
            App.ThreadManager.StartGrilleExecution();
        }

        public void ExecuterStop()
        {
            App.ThreadManager.StopGrilleExecution();
        }
    }
}
