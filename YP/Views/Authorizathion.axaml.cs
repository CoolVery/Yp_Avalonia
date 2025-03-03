using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using YP.ViewModels;

namespace YP.Views;

public partial class Authorizathion : UserControl
{
    public Authorizathion()
    {
        InitializeComponent();
        DataContext = new AuthorizathionViewModel();
    }
}