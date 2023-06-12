using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Portfel.Data;

namespace Portfel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        #region Private members
        private readonly ServiceProvider serviceProvider;
        #endregion
        #region Constructor
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<TransactionDbContext>(options =>
            {
                options.UseSqlite("Data Source = Transaction.db");
            });
            services.AddSingleton<TransactionHistory>();                  //
            serviceProvider = services.BuildServiceProvider();
        }
        #endregion
        #region Event Handlers
        private void OnStartup(object s, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<TransactionHistory>();  //
            mainWindow.Show();
        }
        #endregion
    }
}
