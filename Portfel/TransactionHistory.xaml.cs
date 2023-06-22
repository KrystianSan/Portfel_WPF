using Portfel.Data;
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
using System.Windows.Shapes;

namespace Portfel
{
    /// <summary>
    /// Logika interakcji dla klasy TransactionHistory.xaml
    /// </summary>
    public partial class TransactionHistory : Window   
    {

        
        

        public TransactionHistory()
        {
            
            InitializeComponent();
            

        }

        
        private void btnManage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow manageWindow= new MainWindow();
            manageWindow.Show();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnStats_Click(object sender, RoutedEventArgs e)
        {
            Stats statsWindow= new Stats();
            statsWindow.Show();
        }
    }
}
