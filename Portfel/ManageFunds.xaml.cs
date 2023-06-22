using Portfel.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
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

            //Get amount value
            decimal boxBalance = Convert.ToDecimal(addAmountTextBox.Text);

            // Simulate adding money to the wallet
            walletBalance += boxBalance;
            UpdateBalanceText();

            // Clear the TextBox after adding money
            transactionNameTextBox.Clear();
            addAmountTextBox.Clear();

            Transaction transaction = new Transaction
            {
                
                TransactionName = transactionName,
                Amount = boxBalance,
                TransactionType = true
            };

            TransactionData.AddTransactionToDB(transaction);

            // Display a message box with the transaction details
            MessageBox.Show($"Added $ {boxBalance} to the wallet.\nTransaction Name: {transactionName}");


        }

        private void RemoveMoney_Click(object sender, RoutedEventArgs e)
        {
            // Get transaction name from the TextBox
            string transactionName = transactionNameTextBox.Text;                   //Bład przy pustym TextBox
            decimal boxBalance = Convert.ToDecimal(addAmountTextBox.Text);

            //Get amount value
            if(boxBalance == null)
            {
                 MessageBox.Show($"Enter ammount of money");
                return;
            }
            
            

            // Simulate removing money from the wallet
            if (walletBalance >= boxBalance)
            {
                walletBalance -= boxBalance;
                UpdateBalanceText();

                // Clear the TextBox after removing money
                transactionNameTextBox.Clear();
                addAmountTextBox.Clear();

                // Display a message box with the transaction details

                
                MessageBox.Show($"Removed $ {addAmountTextBox.Text} from the wallet.\nTransaction Name: {transactionName}");
            }
            else
            {
                MessageBox.Show($"There are not enough funds in the account. Transaction cancelled.");

                transactionNameTextBox.Clear();
                addAmountTextBox.Clear();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
