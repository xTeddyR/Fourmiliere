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
                Dessine();
            }
        }

        public void Dessine()
        {
            InitPlateau();
            AddingGround();
            AjouterFourmilliere();
            foreach (Case caseNotEmpty in App.PlateauManager.CasesList) {
                var creatureSurCase = caseNotEmpty.GetCreaturesSurCase();
                if (creatureSurCase.Count() > 0) {
                    foreach (Fourmi fourmi in creatureSurCase) {
                        System.Windows.Controls.Image img = new Image();
                        ConvertisseurAttitudeVersImage Convertisseur = new ConvertisseurAttitudeVersImage();

                        string path = (string)Convertisseur.Convert(fourmi.Comportement, null, null, CultureInfo.CurrentCulture);

                        Uri uri = new Uri(path, UriKind.Absolute);
                        img.Source = new System.Windows.Media.Imaging.BitmapImage(uri);

                        Plateau.Children.Add(img);
                        Grid.SetColumn(img, fourmi.Position.X);
                        Grid.SetRow(img, fourmi.Position.Y);
                    }
                }
            }
        }

        public void InitPlateau()
        {
            Plateau.ColumnDefinitions.Clear();
            Plateau.RowDefinitions.Clear();
            Plateau.Children.Clear();
            for (int i = 0; i < App.fourmilliereVM.DimensionX; i++) {
                Plateau.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < App.fourmilliereVM.DimensionY; i++) {
                Plateau.RowDefinitions.Add(new RowDefinition());
            }
        }

        private void AddingGround()
        {
            for (int i = 0; i < App.fourmilliereVM.DimensionX; i++) {
                for (int j = 0; j < App.fourmilliereVM.DimensionY; j++) {
                    Image img = new Image();
                    Uri uri = new Uri("pack://application:,,,/Resources/ground-png.png", UriKind.Absolute);
                    img.Source = new System.Windows.Media.Imaging.BitmapImage(uri);
                    img.HorizontalAlignment = HorizontalAlignment.Stretch;
                    img.VerticalAlignment = VerticalAlignment.Stretch;
                    img.Stretch = Stretch.Fill;

                    Plateau.Children.Add(img);
                    Grid.SetColumn(img, i);
                    Grid.SetRow(img, j);
                }
            }
        }

        private void AjouterFourmilliere()
        {
            Image img = new Image();
            Uri uri = new Uri("pack://application:,,,/Resources/fourmilliere.png", UriKind.Absolute);
            img.Source = new System.Windows.Media.Imaging.BitmapImage(uri);
            img.HorizontalAlignment = HorizontalAlignment.Stretch;
            img.VerticalAlignment = VerticalAlignment.Stretch;
            img.Stretch = Stretch.Fill;

            Plateau.Children.Add(img);
            Grid.SetColumn(img, ConfigFourmi.FourmilierePositionX);
            Grid.SetRow(img, ConfigFourmi.FourmilierePositionY);
        }

        public void ExecuterTourSuivant()
        {
            App.fourmilliereVM.TourSuivant();
            Dessine();
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
