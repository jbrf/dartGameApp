using dartGameApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace dartGameApp.View
{
    /// <summary>
    /// Interaction logic for TacticsGame.xaml
    /// </summary>
    public partial class TacticsGame : UserControl
    {
        public TacticsGame()
        {
            InitializeComponent();
            var viewmodel = new TacticsGameViewModel();
            this.DataContext = viewmodel;
        }
    }
}
