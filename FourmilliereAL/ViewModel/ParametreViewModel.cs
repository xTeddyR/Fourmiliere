using FourmilliereAL.Core;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;

namespace FourmilliereAL
{
    class ParametreViewModel : BaseViewModel
    {
        public bool isEnabled;
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        #region Commandes
        public ICommand SaveDataCommand { get; set; }
        public ICommand LoadDataCommand { get; set; }
        #endregion

        #region Constructeur
        /// <summary>
        /// Le constructeur par défaut
        /// </summary>
        public ParametreViewModel()
        {
            SaveDataCommand = new RelayCommand(() => SaveData());
            LoadDataCommand = new RelayCommand(() => LoadData());
        }
        #endregion

        public void SaveData()
        {
            App.fourmilliereVM.SaveDataToXML();
            MessageBox.Show("Données sauvegardés dans data.xml !");
            IsEnabled = true;
        }

        public void LoadData()
        {
            OpenFileDialog fileToLoadXml = new OpenFileDialog();
            fileToLoadXml.Filter = "XML Files (*.xml)|*.xml";
            fileToLoadXml.FilterIndex = 1;
            fileToLoadXml.Multiselect = false;

            if (fileToLoadXml.ShowDialog() == true) {
                App.fourmilliereVM.LoadDataFromXml(fileToLoadXml.FileName);
                IsEnabled = false;
                App.GrilleManager.Dessine();
            }
        }
    }
}
