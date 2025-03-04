using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using YP.Models;
using YP.ViewModels;

namespace YP.Views;

public partial class Manager : UserControl
{
    public Manager(User currentUser)
    {
        InitializeComponent();
        DataContext = new ManagerViewModel(currentUser);
    }
}