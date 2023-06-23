using Microsoft.EntityFrameworkCore;
using Portfel.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
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
    /// Logika interakcji dla klasy Stats.xaml
    /// </summary>
    public partial class Stats : Window
    {
        public ObservableCollection<Data.Transaction> transactionsGroup;
        public ObservableCollection<Data.Transaction> transactionsPlanned;
        public string groupName;
        public decimal balance;

        
        


        public Stats()
        {
            InitializeComponent();

            
            balance = Convert.ToDecimal(TransactionData.GetBalance());

            groupNameBoxS.SelectedIndex = 1;
            
            

            //groupName = groupNameBoxS.Text;
            //groupName = 

            
            transactionsPlanned = new ObservableCollection<Transaction>(Data.TransactionData.GetPlannedList());
plannedSDG.ItemsSource = transactionsPlanned;
            GetPlannedSums();
            GetBalanceSum();
            

        }
        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            groupName = groupNameBoxS.Text;
          
        }

        private void GetPlannedSums()
        {
            using (var db = new TransactionContext())
            {
                var dataIncome = db.Transactions.Where(x => x.TransactionType == true && x.date>DateTime.Now).Select(x => x.Amount).ToList();
                decimal sum = 0;
                decimal sum1 = 0;

                foreach(var t in dataIncome)
                {
                    sum += Convert.ToDecimal(t);
                }

                plannedIncomeNumberS.Text = sum.ToString();

                var dataOutcome = db.Transactions.Where(x => x.TransactionType == false).Select(x => x.Amount).ToList();
                foreach (var t in dataOutcome)
                {
                    sum1 += Convert.ToDecimal(t);
                }

                plannedOutcomeNumberS.Text = sum1.ToString();


            }

        }

        

        private void SerchBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = groupNameBoxS.Text;
            
            using (var db = new TransactionContext())
            {
                var dataGroup = db.Transactions.Where(b => b.Group == name ).ToList();

                groupSDG.ItemsSource = null;
                groupSDG.ItemsSource = dataGroup;

            }
            


        }
        private void GetBalanceSum()
        {
            decimal plannedIncome = Convert.ToDecimal(plannedIncomeNumberS.Text);
            decimal plannedOutcome = Convert.ToDecimal(plannedOutcomeNumberS.Text);
            decimal plannedBalance = balance + (plannedIncome - plannedOutcome);
            plannedBalanceNumberS.Text = plannedBalance.ToString();

        }
    }
}
