using FourmilliereAL.Core;
using System.Windows;
using System.Windows.Input;

namespace FourmilliereAL
{
    /// <summary>
    /// Modèle de vue pour la fenêtre custom flat design
    /// </summary>
    class WindowViewModel : BaseViewModel
    {
        #region Membres publiques

        public int MinimumHeight { get; set; } = 200;

        public int MinimumWidth { get; set; } = 200;

        public bool Borderless => (window.WindowState == WindowState.Maximized || dockerPosition != WindowDockPosition.Undocked);

        /// <summary>
        /// La taille du redimensionnment
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// La taille du redimensionnement de la bordure en prenant en compte la marge exterieur
        /// </summary>
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);

        /// <summary>
        /// Le padding du contenu de la fenêtre
        /// </summary>
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        /// <summary>
        /// Marge exterieur pour l'ombre
        /// </summary>
        public int OuterMarginSize
        {
            get => Borderless ? 0 : outerMargin;
            set => outerMargin = value;
        }

        /// <summary>
        /// Marge exterieur pour l'ombre
        /// </summary>
        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);

        /// <summary>
        /// Radius des angles de la fenêtre
        /// </summary>
        public int WindowRadius
        {
            get => Borderless ? 0 : windowRadius;
            set => windowRadius = value;
        }

        /// <summary>
        /// Radius des angles de la fenêtre
        /// </summary>
        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        /// <summary>
        /// La taille de la barre de titre / caption de la fenêtre
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// La taille de la barre de titre / caption de la fenêtre
        /// </summary>
        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

        public string AppTitle { get; set; } = Config.APPLICATION_TITRE;

        #endregion

        #region Membres privés
        /// <summary>
        /// La fenêtre que ce modèle de vue controle
        /// </summary>
        Window window;

        private WindowResizer windowResizer;

        /// <summary>
        /// Marge exterieur pour l'ombre
        /// </summary>
        private int outerMargin = 10;

        /// <summary>
        /// Radius des angles de la fenêtre
        /// </summary>
        private int windowRadius = 10;

        private WindowDockPosition dockerPosition = WindowDockPosition.Undocked;

        private Fourmi selectedAnt = App.fourmilliereVM.FourmisSelect;

        #endregion

        #region Commandes

        public ICommand MinimizedCommand { get; set; }
        public ICommand MaximizedCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }
        public ICommand AddAntCommand { get; set; }
        public ICommand DeleteAntCommand { get; set; }


        #endregion

        #region Constructeur
        /// <summary>
        /// Le constructor par défaut
        /// </summary>
        public WindowViewModel(Window window)
        {
            this.window = window;

            window.StateChanged += (sender, e) => {
                WindowResized();
            };


            // Command init

            MinimizedCommand = new RelayCommand(() => window.WindowState = WindowState.Minimized);
            MaximizedCommand = new RelayCommand(() => window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => CloseApp());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(window, GetMousePosition()));
            AddAntCommand = new RelayCommand(() => App.fourmilliereVM.AjouterFourmis());
            DeleteAntCommand = new RelayCommand(() => App.fourmilliereVM.SupprimerFourmisSelect());

            windowResizer = new WindowResizer(window);

            windowResizer.WindowDockChanged += (dock) => {
                dockerPosition = dock;

                WindowResized();
            };
        }
        #endregion

        #region Helper privé

        public Point GetMousePosition()
        {
            var position = Mouse.GetPosition(window);
            return new Point(position.X + window.Left, position.Y + window.Top);
        }

        public void CloseApp()
        {
            App.ThreadManager.StopGrilleExecution();
            window.Close();
        }

        public void WindowResized()
        {
            OnPropertyChanged(nameof(Borderless));
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }

        #endregion
    }
}
