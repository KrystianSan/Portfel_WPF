using Portfel.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        
        string groupNameText;
        public string balanceO;



        public MainWindow()
        {
            InitializeComponent();
            
            //string groupNameText;
            groupNameBox.SelectedIndex = 0;
            balanceO = TransactionData.GetBalance();
            
            UpdateBalanceText();
        }

        private void UpdateBalanceText()
        {
            var balance = TransactionData.GetBalance();
            balanceO = balance;
       
            balanceText.Text = balance.ToString(); // Display balance as currency

        }
        

        private void AddMoney_Click(object sender, RoutedEventArgs e)
        {
            
            // Get transaction name from the TextBox
            string transactionName = transactionNameTextBox.Text;
            decimal baseBalance = Convert.ToDecimal(balanceO);

            //Get amount value



            DateTime selectedDate;

            if(customDate.IsChecked ==true)
            {
                selectedDate = (DateTime)transactionDate.SelectedDate;
            }
            else
            {
                selectedDate = DateTime.Now;
            }

            //Validation
            string errorMessage = TransactionValidation.ValidateTransaction(transactionName, addAmountTextBox.Text, selectedDate);

            if(errorMessage != "")
            {
                ShowErrors(errorMessage);
                return;

            }
            
            decimal boxBalance = Convert.ToDecimal(addAmountTextBox.Text);
            // Simulate adding money to the wallet
            
            

            // Clear the TextBox after adding money
            transactionNameTextBox.Clear();
            addAmountTextBox.Clear();

            Transaction transaction = new Transaction
            {

                TransactionName = transactionName,
                Amount = boxBalance,
                Group = groupNameBox.Text,
                date = selectedDate,
                TransactionType = true,
                BalanceAfter = baseBalance + boxBalance
            };

            TransactionData.AddTransactionToDB(transaction);
            UpdateBalanceText();
            // Display a message box with the transaction details
            MessageBox.Show($"Added $ {boxBalance} to the wallet.\nTransaction Name: {transactionName}");


        }

        private void RemoveMoney_Click(object sender, RoutedEventArgs e)
        {
            // Get transaction name from the TextBox
            string transactionName = transactionNameTextBox.Text;                   //Bład przy pustym TextBox
            decimal boxBalance = Convert.ToDecimal(addAmountTextBox.Text);
            decimal baseBalance = Convert.ToDecimal(balanceO);
            
            //Get amount value
            if (addAmountTextBox.Text == "")
            {
                MessageBox.Show($"Enter ammount of money");
                return;
            }

            

            // Simulate removing money from the wallet
           
                


                DateTime selectedDate;

                if (customDate.IsChecked == true)
                {
                    selectedDate = (DateTime)transactionDate.SelectedDate;
                }
                else
                {
                    selectedDate = DateTime.Now;
                }

                //Validation
                string errorMessage = TransactionValidation.ValidateTransaction(transactionName, addAmountTextBox.Text, selectedDate);

                if (errorMessage != "")
                {
                    ShowErrors(errorMessage);
                    return;

                }
                
                
                
                if(baseBalance<=boxBalance)
                {
                    MessageBox.Show($"There are not enough funds in the account. Transaction cancelled.");

                    transactionNameTextBox.Clear();
                    addAmountTextBox.Clear();
                    return;
                }
                // Clear the TextBox after removing money
                transactionNameTextBox.Clear();
                addAmountTextBox.Clear();




            // Display a message box with the transaction details

            Transaction transaction = new Transaction
            {

                TransactionName = transactionName,
                Amount = boxBalance,
                Group = groupNameText,
                date = selectedDate,
                TransactionType = false,
                BalanceAfter = baseBalance - boxBalance
                };

                TransactionData.AddTransactionToDB(transaction);
                UpdateBalanceText();
                MessageBox.Show($"Removed $ {boxBalance} from the wallet.\nTransaction Name: {transactionName}");
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void groupNameBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            groupNameText = groupNameBox.Text;
        }

        private void ShowErrors(string error)
        {
            MessageBox.Show(error);
        }
    }
}
