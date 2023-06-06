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

namespace Portfel
{
    public partial class MainWindow : Window
    {
        private decimal walletBalance;

        public MainWindow()
        {
            InitializeComponent();
            walletBalance = 0;
            UpdateBalanceText();
        }

        private void UpdateBalanceText()
        {
            balanceText.Text = walletBalance.ToString("C"); // Display balance as currency
        }

        private void AddMoney_Click(object sender, RoutedEventArgs e)
        {
            // Get transaction name from the TextBox
            string transactionName = transactionNameTextBox.Text;
            string boxBalance = balance;
            // Simulate adding money to the wallet
            walletBalance += ;
            UpdateBalanceText();

            // Clear the TextBox after adding money
            transactionNameTextBox.Clear();

            // Display a message box with the transaction details
            MessageBox.Show($"Added $10 to the wallet.\nTransaction Name: {transactionName}");
        }

        private void RemoveMoney_Click(object sender, RoutedEventArgs e)
        {
            // Get transaction name from the TextBox
            string transactionName = transactionNameTextBox.Text;

            // Simulate removing money from the wallet
            if (walletBalance >= 10)
            {
                walletBalance -= 10;
                UpdateBalanceText();

                // Clear the TextBox after removing money
                transactionNameTextBox.Clear();

                // Display a message box with the transaction details
                MessageBox.Show($"Removed $10 from the wallet.\nTransaction Name: {transactionName}");
            }
        }
    }
}
