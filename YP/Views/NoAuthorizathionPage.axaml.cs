using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using YP.ViewModels;

namespace YP.Views;

public partial class NoAuthorizathionPage : UserControl
{
    public NoAuthorizathionPage()
    {
        DataContext = new NoAuthorizathionPageViewModel();
        InitializeComponent();
    }
}