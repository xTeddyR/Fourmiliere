using System.Windows.Controls;

namespace FourmilliereAL
{
    /// <summary>
    /// Logique d'interaction pour ParametreControle.xaml
    /// </summary>
    public partial class ParametreControle : UserControl
    {
        public ParametreControle()
        {
            InitializeComponent();
            DataContext = new ParametreViewModel();
        }
    }
}
