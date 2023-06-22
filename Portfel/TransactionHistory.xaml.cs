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
        public string RemainingBalance = "";
        
        

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
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void transactionNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void DarkModeToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            App.IsDarkTheme = true;
            ReloadResources();
        }

        private void DarkModeToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            App.IsDarkTheme = false;
            ReloadResources();
        }

        private void ReloadResources()
        {
            Current.Resources.MergedDictionaries.Clear();
            var themeDictionary = new ResourceDictionary();
            themeDictionary.Source = new Uri(App.IsDarkTheme ? "DarkTheme.xaml" : "LightTheme.xaml", UriKind.RelativeOrAbsolute);
            Current.Resources.MergedDictionaries.Add(themeDictionary);
        }
    }
}
