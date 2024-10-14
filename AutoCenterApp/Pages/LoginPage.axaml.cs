using System.Linq;
using AutoCenterApp.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AutoCenterApp.Pages;

public partial class LoginPage : UserControl
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        IsEnabled = false;
        using (var scope = App.ServiceProvider.CreateScope())
        {
            var _context = scope.ServiceProvider.GetRequiredService<AutoCenterDbContext>();
            var person = await _context.Personals.FirstOrDefaultAsync(x => x.PersonalLogin == login.Text)!;
            if (person != null && person.PersonalPassword == password.Text)
            {
                var mainWindow = (MainWindow)this.VisualRoot;
                var mainPage = new MainPage();
                mainWindow.ContentArea.Content = mainPage;
            }
            else if (login.Text.IsNullOrEmpty() || password.Text.IsNullOrEmpty())
            {
                AllertTb.Text = "Заполните все поля";
                IsEnabled = true;
            }
            else
            {
                AllertTb.Text = "Неверный логин или пароль";
                IsEnabled = true;
            }
        }
    }


    private void Check_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        TextBoxPassword.Text = password.Text;
        password.IsVisible = false;
        TextBoxPassword.IsVisible = true;
    }

    private void Check_OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        password.Text = TextBoxPassword.Text;
        TextBoxPassword.IsVisible = false;
        password.IsVisible = true;
    }
}