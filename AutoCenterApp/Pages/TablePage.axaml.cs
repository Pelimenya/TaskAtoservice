using System.Linq;
using AutoCenterApp.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Avalonia.Media;

namespace AutoCenterApp.Pages;

public partial class TablePage : UserControl
{
    public TablePage()
    {
        InitializeComponent();
        _context = App.ServiceProvider.GetService<AutoCenterDbContext>();
        GetData();
        cbFilter.SelectedIndex = 0;
    }

    private AutoCenterDbContext _context;

    private List<Order> _orders = new List<Order>();

    private void GetData()
    {
        
        _orders = _context.Orders
            .Include(o => o.OrderAutoNavigation)
                .ThenInclude(a => a.AutoModelNavigation)
                .ThenInclude(m => m.Mark)
            .Include(o => o.OrderAutoNavigation)
                .ThenInclude(a => a.AutoOwnerNavigation)
            .Include(o => o.OrderStatusNavigation)
            .ToList();

        UpdateDataGrid();
        Dg.ItemsSource = _orders;
    }

    private void UpdateDataGrid()
    {
        var filteredOrders = _orders.AsQueryable();

        // Фильтрация по статусу
        var selectedStatus = (cbFilter.SelectedItem as ComboBoxItem)?.Content?.ToString();
        if (selectedStatus != "Все" && !string.IsNullOrEmpty(selectedStatus))
        {
            filteredOrders = filteredOrders.Where(o => o.OrderStatusNavigation.StatusName == selectedStatus);
        }

        // Поиск по номеру или клиенту
        var searchText = tbSearch.Text?.ToLower();
        if (!string.IsNullOrEmpty(searchText))
        {
            filteredOrders = filteredOrders.Where(o =>
                (o.OrderAutoNavigation.StateNumber != null && o.OrderAutoNavigation.StateNumber.ToLower().Contains(searchText)) ||
                (o.OrderAutoNavigation.AutoOwnerNavigation.FullName != null && o.OrderAutoNavigation.AutoOwnerNavigation.FullName.ToLower().Contains(searchText)) ||
                (o.OrderAutoNavigation.AutoModelNavigation.Mark.MarkName != null && o.OrderAutoNavigation.AutoModelNavigation.Mark.MarkName.ToLower().Contains(searchText)) ||
                (o.OrderAutoNavigation.AutoModelNavigation.ModelName != null && o.OrderAutoNavigation.AutoModelNavigation.ModelName.ToLower().Contains(searchText))
            );
        }

        // Обновляем источник данных для DataGrid
        Dg.ItemsSource = filteredOrders.ToList();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = (MainWindow)this.VisualRoot;
        MainPage mainPage = new MainPage();
        mainWindow.ContentArea.Content = mainPage;
    }

    private void TbSearch_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        UpdateDataGrid();
    }

    private void CbFilter_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        UpdateDataGrid();
    }

    private void DataGrid_OnLoadingRow(object? sender, DataGridRowEventArgs e)
    {
        // Получаем текущий элемент данных для строки
        var order = e.Row.DataContext as Order; // Убедитесь, что Order — это ваш класс модели

        if (order != null)
        {
            // Пример: меняем цвет фона строки в зависимости от статуса
            if (order.OrderStatusNavigation.StatusName == "Выполнено")
            {
                e.Row.Background = Brushes.DarkSlateGray;
            }
            else if (order.OrderStatusNavigation.StatusName == "Запланированно")
            {
                e.Row.Background = Brushes.YellowGreen;
            }
            else if (order.OrderStatusNavigation.StatusName == "Принята к исполнению")
            {
                e.Row.Background = Brushes.DarkSlateBlue;
            }
        
        }
    }
    
    private void Button_OnClick_Exit(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = (MainWindow)this.VisualRoot;
        LoginPage lp = new LoginPage();
        mainWindow.ContentArea.Content = lp;
    }
}
