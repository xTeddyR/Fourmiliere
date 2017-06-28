using System;
using System.Linq;
using System.Windows.Controls;
using FourmilliereAL.Core;
using System.Windows;
using System.Windows.Media;
using System.Globalization;

namespace FourmilliereAL
{
    public class GrilleManager
    {
        private Grid plateau { get; set; }

        public Grid Plateau
        {
            get
            {
                return plateau;
            }
            set
            {
                plateau = value;
            }
        }
        public void Dessine()
        {
            InitPlateau();
            AddingGround();
            AjouterFourmilliere();
            AjouterFruit();
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
        public void AddingGround()
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

        public void AjouterFourmilliere()
        {
            Image img = new Image();
            Uri uri = new Uri("pack://application:,,,/Resources/fourmilliere.png", UriKind.Absolute);
            img.Source = new System.Windows.Media.Imaging.BitmapImage(uri);
            img.HorizontalAlignment = HorizontalAlignment.Stretch;
            img.VerticalAlignment = VerticalAlignment.Stretch;
            img.Stretch = Stretch.Fill;

            Plateau.Children.Add(img);
            Grid.SetColumn(img, ConfigFourmi.FOURMILIERE_POSITION_X);
            Grid.SetRow(img, ConfigFourmi.FOURMILIERE_POSITION_Y);
        }

        public void AjouterFruit()
        {
            for (int i = 0; i < App.fourmilliereVM.ListeFruit.Count; i++) {
                var fruit = App.fourmilliereVM.ListeFruit[i];
                Image img = new Image();
                Uri uri = new Uri("pack://application:,,,/Resources/apple.png", UriKind.Absolute);
                img.Source = new System.Windows.Media.Imaging.BitmapImage(uri);

                Plateau.Children.Add(img);
                Grid.SetColumn(img, fruit.Position.X);
                Grid.SetRow(img, fruit.Position.Y);

            }
            
        }
    }
}
