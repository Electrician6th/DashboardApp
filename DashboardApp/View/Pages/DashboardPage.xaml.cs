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

namespace DashboardApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            InitializeComponent();
            LoadData(); 

        }

        private void LoadData()
        {
            FridgeCountTbl.Text = App.context.Warehouses.Count().ToString();
            FridgeCountTbl.Text = App.context.Products.Count().ToString();
            WarehousesCountTbl2.Text = App.context.Suppliers.Count().ToString();
        }
    }
}
