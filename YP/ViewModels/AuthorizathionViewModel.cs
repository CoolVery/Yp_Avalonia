using System;
using System.Collections.Generic;
using System.Linq;
using ReactiveUI;
using YP.Models;
using YP.Views;

namespace YP.ViewModels
{
	public class AuthorizathionViewModel : ReactiveObject
	{
        string idNumber;
		string password;

        public string IdNumber { get => idNumber; set => this.RaiseAndSetIfChanged(ref idNumber, value); }
        public string Password { get => password; set => this.RaiseAndSetIfChanged(ref password, value); }

        public void AuthorizathionInSystem()
        {
            User currentUser = MainWindowViewModel.Instance.Dbcontext.Users.FirstOrDefault(x => x.Id == Convert.ToInt32(IdNumber) && x.Password == x.Password);
            switch (currentUser)
            {
                case null:

                    break;
                default:
                    switch (currentUser.IdRole)
                    {
                        case 3:
                            MainWindowViewModel.Instance.Uc = new Manager(currentUser);
                            break;
                    }
                    break;
            }
        }
    }
}