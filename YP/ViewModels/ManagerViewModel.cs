using System;
using System.Collections.Generic;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using ReactiveUI;
using YP.Models;
using YP.Views;

namespace YP.ViewModels
{
	public class ManagerViewModel : ReactiveObject
	{
		User currentUser;
		string hellowStringInSystem;
        Bitmap userImage;
        public User CurrentUser { get => currentUser; set => currentUser = value; }
        public string HellowStringInSystem { get => hellowStringInSystem; set => this.RaiseAndSetIfChanged( ref hellowStringInSystem, value); }
        public Bitmap UserImage { get => userImage; set => this.RaiseAndSetIfChanged(ref userImage, value); }

        List<TimeSpan> periodValues = new List<TimeSpan>()
        {
            new TimeSpan(9, 0, 0),
            new TimeSpan(11, 0, 0),
            new TimeSpan(11, 1, 0),
            new TimeSpan(18, 0, 0),
        };
        public ManagerViewModel(User currentUser)
		{
            string nameAndGenderUser = "";
			this.currentUser = currentUser;
            string imagePath = @"avares://Yp/Assets/users/" + currentUser.Image;
            userImage = new Bitmap(AssetLoader.Open(new Uri(imagePath)));

            switch (currentUser.IdGender)
            {
                case 1:
                    nameAndGenderUser = $"Mrs {currentUser.FullName}";
                    break;
                case 2:
                    nameAndGenderUser = $"Ms {currentUser.FullName}";
                    break;
            }
            DateTime dateTime = DateTime.Now;
            if (periodValues[0] <= dateTime.TimeOfDay && periodValues[1] >= dateTime.TimeOfDay)
            {
                hellowStringInSystem = $"Доброе утро!\n" + nameAndGenderUser;
            }
            else if (periodValues[2] <= dateTime.TimeOfDay && periodValues[3] >= dateTime.TimeOfDay)
            {
                hellowStringInSystem = $"Добрый день!\n" + nameAndGenderUser;
            }
            else
            {
                hellowStringInSystem = $"Добрый вечер!\n" + nameAndGenderUser;
            }

        }
        public void ToRegistrathionModeratorOrJury()
        {
            MainWindowViewModel.Instance.Uc = new RegistrathionModeratorOrJury();
        }
    }
}