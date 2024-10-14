using AutoCenterApp.Pages;
using Avalonia.Controls;
using Avalonia.Media;
using static Avalonia.Controls.Window;

namespace AutoCenterApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
        ContentArea.Content = new LoginPage();
       
    }
}