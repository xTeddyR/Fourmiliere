using System.Windows.Controls;

namespace FourmilliereAL
{
    /// <summary>
    /// Logique d'interaction pour Grille.xaml
    /// </summary>
    public partial class Grille : UserControl
    {
        public Grille()
        {
            InitializeComponent();
            DataContext = new GrilleViewModel(Plateau);
        }
    }
}
