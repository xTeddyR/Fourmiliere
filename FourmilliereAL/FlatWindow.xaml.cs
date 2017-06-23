using System.Windows;

namespace FourmilliereAL
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class FlatWindow : Window
    {
        public FlatWindow()
        {
            InitializeComponent();
            DataContext = new WindowViewModel(this);
        }
    }
}
