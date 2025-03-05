using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using YP.Models;
using YP.ViewModels;

namespace YP.Views;

public partial class RegistrathionModeratorOrJury : UserControl
{
    public RegistrathionModeratorOrJury(User currentUser)
    {
        InitializeComponent();
        DataContext = new RegistrathionModeratorOrJuryViewModel(currentUser);
    }
}