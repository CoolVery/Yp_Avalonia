using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using YP.Models;

namespace YP.ViewModels
{
	public class RegistrathionModeratorOrJuryViewModel : ReactiveObject
	{
		User newUser = new User();
		List<Gender> genders;
        List<Role> roles;
        List<Event> events;
        List<Direction> directions;
        public User NewUser { get => newUser; set => this.RaiseAndSetIfChanged( ref newUser, value); }
        public List<Gender> Genders { get => genders; set => this.RaiseAndSetIfChanged(ref genders, value); }
        public List<Role> Roles { get => roles; set => this.RaiseAndSetIfChanged(ref roles, value); }
        public List<Event> Events { get => events; set => this.RaiseAndSetIfChanged(ref events, value); }
        public List<Direction> Directions { get => directions; set => this.RaiseAndSetIfChanged(ref directions, value); }

        public RegistrathionModeratorOrJuryViewModel()
		{
			Random random = new Random();
			int IdUser = 0;  
			while (true)
			{
				IdUser = random.Next(0, 100000000);
				if ( MainWindowViewModel.Instance.Dbcontext.Users.FirstOrDefault(x => x.Id == IdUser) == null)
				{
					NewUser.Id = IdUser;
					break;
				}

            }
			genders = MainWindowViewModel.Instance.Dbcontext.Genders.ToList();
			roles = MainWindowViewModel.Instance.Dbcontext.Roles.ToList();
			events = MainWindowViewModel.Instance.Dbcontext.Events.ToList();
			directions = MainWindowViewModel.Instance.Dbcontext.Directions.ToList();
        }
    }
}