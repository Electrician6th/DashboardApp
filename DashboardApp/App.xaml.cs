using DashboardApp.Data;
using System.Configuration;
using System.Data;
using System.Net.NetworkInformation;
using System.Windows;

namespace DashboardApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DashboardDb34Context context = new 
            DashboardDb34Context();
    }

}
