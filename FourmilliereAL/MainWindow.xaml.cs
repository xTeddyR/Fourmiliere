﻿using FourmilliereAL.Fabriques;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FourmilliereAL
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        Stopwatch stopWatch = new Stopwatch();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.fourmilliereVM;
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
            foreach(Fourmi fourmi in App.fourmilliereVM.FourmisList)
            {
                Image img = new Image();
                Uri uri = new Uri("Media/warrior-ant.png", UriKind.Relative);
                img.Source = new BitmapImage(uri);

                Plateau.Children.Add(img);
                Grid.SetColumn(img, fourmi.X);
                Grid.SetRow(img, fourmi.Y);
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.fourmilliereVM.AjouterFourmis();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.fourmilliereVM.SupprimerFourmis();
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
    }
}
