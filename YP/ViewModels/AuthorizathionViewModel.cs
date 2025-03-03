using System;
using System.Collections.Generic;
using ReactiveUI;

namespace YP.ViewModels
{
	public class AuthorizathionViewModel : ReactiveObject
	{
        string idNumber;
		string password;

        public string IdNumber { get => idNumber; set => this.RaiseAndSetIfChanged(ref idNumber, value); }
        public string Password { get => password; set => this.RaiseAndSetIfChanged(ref password, value); }
    }
}