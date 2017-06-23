using FourmilliereAL.Core;
using System.Windows;

namespace FourmilliereAL
{
    /// <summary>
    /// Modèle de vue pour la fenêtre custom flat design
    /// </summary>
    class WindowViewModel : BaseViewModel
    {
        #region Membres privés
        /// <summary>
        /// La fenêtre que ce modèle de vue controle
        /// </summary>
        Window window;
        #endregion

        #region Constructeur
        /// <summary>
        /// Le constructor par défaut
        /// </summary>
        public WindowViewModel(Window window)
        {
            this.window = window;
        }
        #endregion
    }
}
