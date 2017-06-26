using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Globalization;
using Microsoft.Win32;
using FourmilliereAL.Core;

namespace FourmilliereAL
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PlateauManager plateauManager;
        DispatcherTimer dt = new DispatcherTimer();
        Stopwatch stopWatch = new Stopwatch();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.fourmilliereVM;
            plateauManager = PlateauManager.Instance;
            dt.Tick += Redessine_Tick;
            dt.Interval = new TimeSpan(0, 0, 0, 0, App.fourmilliereVM.VitesseExecution);      
        }

        private void Redessine_Tick(object sender, EventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                Dessine();
            }
        }

        public void Dessine()
        {
            InitPlateau();
            AddingGround();
            AjouterFourmilliere();
            foreach (Case caseNotEmpty in plateauManager.CasesList)
            {
                var creatureSurCase = caseNotEmpty.GetCreaturesSurCase();
                if (creatureSurCase.Count() > 0)
                {
                    foreach(Fourmi fourmi in creatureSurCase)
                    {
                        Image img = new Image();
                        ConvertisseurAttitudeVersImage Convertisseur = new ConvertisseurAttitudeVersImage();

                        string path = (string)Convertisseur.Convert(fourmi.Comportement, null, null, CultureInfo.CurrentCulture);

                        Uri uri = new Uri(path, UriKind.Absolute);
                        img.Source = new BitmapImage(uri);

                        Plateau.Children.Add(img);
                        Grid.SetColumn(img, fourmi.Position.X);
                        Grid.SetRow(img, fourmi.Position.Y);
                    }
                }
            }            
        }

        private void InitPlateau()
        {
            Plateau.ColumnDefinitions.Clear();
            Plateau.RowDefinitions.Clear();
            Plateau.Children.Clear();
            for (int i = 0; i < App.fourmilliereVM.DimensionX; i++)
            {
                Plateau.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < App.fourmilliereVM.DimensionY; i++)
            {
                Plateau.RowDefinitions.Add(new RowDefinition());
            }
        }

        private void AddingGround() 
        {
            for (int i = 0; i < App.fourmilliereVM.DimensionX; i++) 
            {
                for (int j = 0; j < App.fourmilliereVM.DimensionY; j++) 
                {
                    Image img = new Image();
                    Uri uri = new Uri("Media/ground-png.png", UriKind.Relative);
                    img.Source = new BitmapImage(uri);
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
            Uri uri = new Uri("Media/fourmilliere.png", UriKind.Relative);
            img.Source = new BitmapImage(uri);
            img.HorizontalAlignment = HorizontalAlignment.Stretch;
            img.VerticalAlignment = VerticalAlignment.Stretch;
            img.Stretch = Stretch.Fill;

            Plateau.Children.Add(img);
            Grid.SetColumn(img, ConfigFourmi.FOURMILIERE_POSITION_X);
            Grid.SetRow(img, ConfigFourmi.FOURMILIERE_POSITION_Y);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.fourmilliereVM.AjouterFourmis();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.fourmilliereVM.SupprimerFourmisSelect();
        }

        private void btnSuivant_Click(object sender, RoutedEventArgs e)
        {
            App.fourmilliereVM.TourSuivant();
            Dessine();
        }

        private void btnAvance_Click(object sender, RoutedEventArgs e)
        {
            stopWatch.Start();
            dt.Start();
            Thread tt = new Thread(App.fourmilliereVM.Avance);
            tt.Start();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            App.fourmilliereVM.Stop();
            if (stopWatch.IsRunning)
            {
                stopWatch.Stop();
            }
        }

        private void Save_Data_Button_Click(object sender, RoutedEventArgs e)
        {
            App.fourmilliereVM.SaveDataToXML();
            MessageBox.Show("Données sauvegardés dans data.xml !");
        }

        private void Load_Data_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileToLoadXml = new OpenFileDialog();
            fileToLoadXml.Filter = "XML Files (*.xml)|*.xml";
            fileToLoadXml.FilterIndex = 1;
            fileToLoadXml.Multiselect = false;

            if (fileToLoadXml.ShowDialog() == true)
            {
                App.fourmilliereVM.LoadDataFromXml(fileToLoadXml.FileName);
                LoadDataButton.IsEnabled = false;
                Dessine();
            }
        }
    }
}
