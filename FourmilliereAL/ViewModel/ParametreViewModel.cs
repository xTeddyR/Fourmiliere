using FourmilliereAL.Core;
using Microsoft.Win32;
using System.IO;
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
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "XML files (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == true)
            {
                    App.fourmilliereVM.SaveDataToXML(saveFileDialog1.FileName);
                    MessageBox.Show("Données sauvegardés !");
            }
        }

        public void LoadData()
        {
            OpenFileDialog fileToLoadXml = new OpenFileDialog();
            fileToLoadXml.Filter = "XML Files (*.xml)|*.xml";
            fileToLoadXml.FilterIndex = 1;
            fileToLoadXml.Multiselect = false;

            if (fileToLoadXml.ShowDialog() == true) {
                App.fourmilliereVM.LoadDataFromXml(fileToLoadXml.FileName);
                App.GrilleManager.Dessine();
            }
        }
    }
}
