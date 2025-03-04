using Avalonia.Controls;
using ReactiveUI;
using YP.Models;
using YP.Views;

namespace YP.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        static MainWindowViewModel instance;
        UserControl uc;
        PostgresContext dbcontext = new PostgresContext();

        public static MainWindowViewModel Instance { get => instance; set => instance = value; }
        public UserControl Uc { get => uc; set => uc = this.RaiseAndSetIfChanged(ref uc, value); }
        public PostgresContext Dbcontext { get => dbcontext; set => dbcontext = value; }

        public MainWindowViewModel()
        {
            instance = this;      
            uc = new NoAuthorizathionPage();
        }
    }
}
