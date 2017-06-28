using System.Windows.Controls;
using FourmilliereAL.Core;

namespace FourmilliereAL
{
    /// <summary>
    /// Logique d'interaction pour TimeItemControle.xaml
    /// </summary>
    public partial class TimeItemControle : UserControl
    {
        public TimeItemControle()
        {
            InitializeComponent();
            DataContext = Environnement.Instance.Heure;
        }
    }
}
