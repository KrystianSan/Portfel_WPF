using Portfel.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Portfel
{
    /// <summary>
    /// Logika interakcji dla klasy TransactionHistory.xaml
    /// </summary>
    public partial class TransactionHistory : Window   
    {
        public string RemainingBalance;

        public ObservableCollection<Data.Transaction> transactionsIncome;
        public ObservableCollection<Data.Transaction> transactionsOutcome;
        public string balance;



        public TransactionHistory()
        {
            
            InitializeComponent();
            
            
            transactionsIncome = new ObservableCollection<Data.Transaction>(TransactionData.GetIncomeList());
            transactionsOutcome = new ObservableCollection<Data.Transaction>(TransactionData.GetOutcomeList());
            
            balance = TransactionData.GetBalance();
            
            walletBallanceTH.Text = balance;

            incomeDG.ItemsSource= transactionsIncome;
            outcomeDG.ItemsSource = transactionsOutcome;
            
        }

        private void UpdateBalanceText()
        {
            var balance = TransactionData.GetBalance();

            walletBallanceTH.Text = balance.ToString(); // Display balance as currency

        }

        private void btnManage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow manageWindow= new MainWindow();
            manageWindow.Show();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnStats_Click(object sender, RoutedEventArgs e)
        {
            Stats statsWindow= new Stats();
            statsWindow.Show();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            UpdateBalanceText();

            outcomeDG.ItemsSource = null;
            incomeDG.ItemsSource = null;

            transactionsIncome = new ObservableCollection<Data.Transaction>(TransactionData.GetIncomeList());
            transactionsOutcome = new ObservableCollection<Data.Transaction>(TransactionData.GetOutcomeList());

            incomeDG.ItemsSource = transactionsIncome;
            outcomeDG.ItemsSource = transactionsOutcome;


        }
    }
}
