using System.Linq;
using AutoCenterApp.Models;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AutoCenterApp.Pages
{
    public partial class MainPage : UserControl
    {
        private AutoCenterDbContext _context;

        public MainPage()
        {
            InitializeComponent();
            
            _context = App.ServiceProvider.GetService<AutoCenterDbContext>();
            GetData();
        }

        private void GetData()
        {
            LvOrders.ItemsSource = _context.Orders.Include(x => x.OrderPersonalNavigation)
                .Include(x => x.OrderAutoNavigation).ThenInclude(x => x.AutoModelNavigation).ThenInclude(x => x.Mark)
                .Include(x => x.OrderStatusNavigation).ToList();
        }

        private void Button_OnClick(object? sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)this.VisualRoot;
            var tablePage = new TablePage();
            mainWindow.ContentArea.Content = tablePage;
        }

        private void Button_OnClick_Exit(object? sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)this.VisualRoot;
            LoginPage lp = new LoginPage();
            mainWindow.ContentArea.Content = lp;
        }
    }
}