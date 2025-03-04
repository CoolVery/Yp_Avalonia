using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using YP.ViewModels;

namespace YP.Views;

public partial class RegistrathionModeratorOrJury : UserControl
{
    public RegistrathionModeratorOrJury()
    {
        InitializeComponent();
        DataContext = new RegistrathionModeratorOrJuryViewModel();
    }
}