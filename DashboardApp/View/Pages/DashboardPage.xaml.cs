using DashboardApp.Models;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
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
            FridgeCountTbl.Text = App.context.Fridges.Count().ToString();
            SupplierCountTbl.Text=App.context.Suppliers.Count().ToString();
            ProductCountTbl.Text=App.context.Products.Count().ToString();

            //Весь доступный обьем
            GeneralCountTbl.Text = App.context.Fridges.Sum(fridge => fridge.TotalVolume).ToString("F0") + " л";
            //Занято
            FreeCountTbl.Text = App.context.Fridges.Sum(fridge => fridge.UsedVolume).ToString("F0") + " л";
            //Свободно
            BusyCountTbl.Text = App.context.Fridges.Sum(fridge => fridge.TotalVolume - fridge.UsedVolume).ToString("F0") + " л";

            //Накладные
            CurrentYearReceioTbl.Text = App.context.Receipts.Count(receipt => receipt.Date.Year == DateTime.Now.Year).ToString();
            AverageProductInReceiptTBl.Text = App.context.Receipts.Average(receipt => (double) receipt.ProductReceipts.Count()).ToString("F0");
            ProductInReceiptTBl.Text= App.context.ProductReceipts.Count().ToString();
        }

        private void LoadChart()
        {
            //Получаем коллекцию записей
            List <ProductReceipt> productReceipts = App.context.ProductReceipts.ToList();

            //Настройка графика (столбцов)
            ColumnSeries<decimal> series = new ColumnSeries<decimal>()
            {
                Name = "Затраты",
                Values = productReceipts.Select(pr => pr.TotalPrice).ToArray(),
            };

            //Настройка оси X
            Axis xAxis = new Axis
            {
                Labels = productReceipts.Select(pr=>pr.Receipt.Date.ToString()).ToArray(),
            };

            //Настройка оси Y
            Axis yAxis = new Axis
            {
                Labeler = value=>value.ToString()
            };

            Chart.Series = [series]; //если у коллекции поставить квадратные скобки,то произойдет быстрое создание массива
            Chart.XAxes = [xAxis];
            Chart.XAxes = [yAxis];


        }
    }
}
