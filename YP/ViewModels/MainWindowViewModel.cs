using Avalonia.Controls;
using ReactiveUI;
using YP.Views;

namespace YP.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        MainWindowViewModel instance;
        UserControl uc = new Authorizathion();
        public MainWindowViewModel Instance { get => instance; set => instance = value; }
        public UserControl Uc { get => uc; set => uc = this.RaiseAndSetIfChanged(ref uc, value); }

        public MainWindowViewModel()
        {
            instance = this;
        }
    }
}
