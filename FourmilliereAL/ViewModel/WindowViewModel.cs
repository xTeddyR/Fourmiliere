using FourmilliereAL.Core;
using System.Windows;

namespace FourmilliereAL
{
    /// <summary>
    /// Modèle de vue pour la fenêtre custom flat design
    /// </summary>
    class WindowViewModel : BaseViewModel
    {
        #region Membres publiques

        /// <summary>
        /// La taille du redimensionnment
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// La taille du redimensionnement de la bordure en prenant en compte la marge exterieur
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        /// <summary>
        /// Marge exterieur pour l'ombre
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return window.WindowState == WindowState.Maximized ? 0 : outerMargin;
            }

            set
            {
                outerMargin = value;
            }
        }

        /// <summary>
        /// Marge exterieur pour l'ombre
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// Radius des angles de la fenêtre
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return window.WindowState == WindowState.Maximized ? 0 : windowRadius;
            }

            set
            {
                windowRadius = value;
            }
        }

        /// <summary>
        /// Radius des angles de la fenêtre
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// La taille de la barre de titre / caption de la fenêtre
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        #endregion

        #region Membres privés
        /// <summary>
        /// La fenêtre que ce modèle de vue controle
        /// </summary>
        Window window;

        /// <summary>
        /// Marge exterieur pour l'ombre
        /// </summary>
        private int outerMargin = 10;

        /// <summary>
        /// Radius des angles de la fenêtre
        /// </summary>
        private int windowRadius = 10;

        #endregion

        #region Constructeur
        /// <summary>
        /// Le constructor par défaut
        /// </summary>
        public WindowViewModel(Window window)
        {
            this.window = window;

            window.StateChanged += (sender, e) => {

                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));

            };
        }
        #endregion
    }
}
