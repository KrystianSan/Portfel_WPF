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
        public static bool IsDarkTheme { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Load the appropriate theme based on the IsDarkTheme property
            var themeDictionary = new ResourceDictionary();
            themeDictionary.Source = new Uri(IsDarkTheme ? "DarkTheme.xaml" : "LightTheme.xaml", UriKind.RelativeOrAbsolute);
            Current.Resources.MergedDictionaries.Add(themeDictionary);

            // Start your main window or application here
        }

    }
}
