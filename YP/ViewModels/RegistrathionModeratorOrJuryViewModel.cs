using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using DynamicData.Aggregation;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using YP.Models;
using YP.Views;

namespace YP.ViewModels
{
	public class RegistrathionModeratorOrJuryViewModel : ReactiveObject
	{
        User _currentUser;
		User newUser = new User();
		List<Gender> _genders;
        List<Role> _roles;
        Role _selectedRolesForUser;
        List<Event> _events;
        Event _selectedEventForUser;
        string _repeatPassword;
        bool _isWrongRepeatPassword = false;
        bool _isWrongEmail = false;
        bool _isWrongRegexPassword = false;
        List<Direction> _directions;
        Direction _selectedDirectionForUser;
		char _passwordHideChar = '*';
		bool _showPassword = false;
        bool _isCanEventEnable = true;
        bool _isCreatedNewUser = false;
        Bitmap _image;

        public User NewUser { get => newUser; set => this.RaiseAndSetIfChanged(ref newUser, value); }
        public List<Gender> Genders { get => _genders; set => this.RaiseAndSetIfChanged(ref _genders, value); }
        public List<Role> Roles { get => _roles; set => this.RaiseAndSetIfChanged(ref _roles, value); }
        public List<Event> Events { get => _events; set => this.RaiseAndSetIfChanged(ref _events, value); }
        public List<Direction> Directions { get => _directions; set => this.RaiseAndSetIfChanged(ref _directions, value); }
        public char PasswordHideChar { get => _passwordHideChar; set => this.RaiseAndSetIfChanged(ref _passwordHideChar, value); }
        public bool ShowPassword
		{
			get => _showPassword;
			set
			{
				this.RaiseAndSetIfChanged(ref _showPassword, value);
				switch (value)
				{
					case false:
						PasswordHideChar = '*';
						break;
					case true:
						PasswordHideChar = '\0';
						break;
				}
			}
		}
        public Bitmap Image { get => _image; set => this.RaiseAndSetIfChanged(ref _image, value); }
        public bool IsCanEventEnable { get => _isCanEventEnable; set => this.RaiseAndSetIfChanged(ref _isCanEventEnable, value); }
        public Role SelectedRolesForUser
        {
            get => _selectedRolesForUser;
            set
            {
                Role jury = Roles.FirstOrDefault(x => x.Name == "Жюри");
                this.RaiseAndSetIfChanged(ref _selectedRolesForUser, value);
                if (value == jury)
                {
                    IsCanEventEnable = false;
                }
                else
                {
                    IsCanEventEnable = true;
                }
            }
        }

        public Event SelectedEventForUser { get => _selectedEventForUser; set => this.RaiseAndSetIfChanged(ref _selectedEventForUser, value); }
        public string RepeatPassword { get => _repeatPassword; set => this.RaiseAndSetIfChanged(ref _repeatPassword, value); }
        public bool IsWrongRepeatPassword { get => _isWrongRepeatPassword; set => this.RaiseAndSetIfChanged(ref _isWrongRepeatPassword, value); }
        public Direction SelectedDirectionForUser { get => _selectedDirectionForUser; set => this.RaiseAndSetIfChanged(ref _selectedDirectionForUser, value); }
        public bool IsCreatedNewUser { get => _isCreatedNewUser; set => this.RaiseAndSetIfChanged(ref _isCreatedNewUser, value); }
        public bool IsWrongEmail { get => _isWrongEmail; set => this.RaiseAndSetIfChanged(ref _isWrongEmail, value); }
        public bool IsWrongRegexPassword { get => _isWrongRegexPassword; set => this.RaiseAndSetIfChanged(ref _isWrongRegexPassword, value); }

        public RegistrathionModeratorOrJuryViewModel(User currentUser)
        {
            
            Random random = new Random();
            int IdUser = 0;
            while (true)
            {
                IdUser = random.Next(0, 100000000);
                if (MainWindowViewModel.Instance.Dbcontext.Users.FirstOrDefault(x => x.Id == IdUser) == null)
                {
                    NewUser.Id = IdUser;
                    break;
                }

            }
            _genders = MainWindowViewModel.Instance.Dbcontext.Genders.ToList();
            _roles = MainWindowViewModel.Instance.Dbcontext.Roles.Where(x => x.Name != "Участник" && x.Name != "Организатор").ToList();
            _events = MainWindowViewModel.Instance.Dbcontext.Events.ToList();
            _directions = MainWindowViewModel.Instance.Dbcontext.Directions.ToList();
            _currentUser = currentUser; 
        }
        /// <summary>
        /// Select image for user
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        public async void ChangeImg()
        {
            //Открытие окна Windows
            if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
                desktop.MainWindow?.StorageProvider is not { } provider)
                throw new NullReferenceException("Missing StorageProvider instance.");

            var files = await provider.OpenFilePickerAsync(new FilePickerOpenOptions()
            {
                Title = "Выбрать изображение",
                AllowMultiple = false
            });
            if (files.Count == 0)
            {

                return;
            }
            //Обработка изображения
            await using var readStream = await files[0].OpenReadAsync();
            byte[] buffer = new byte[10000000];
            var bytes = readStream.ReadAtLeast(buffer, 1);
            Array.Resize(ref buffer, bytes);
            Image = new Bitmap(new MemoryStream(buffer));
            //Получаем имя файла
            NewUser.Image = files[0].Name;
        }
        /// <summary>
        /// Save new user in DB
        /// </summary>
        public void SaveNewJuryOrModerator()
        {
            Regex regexEmail = new Regex(@"^[a-zA-Z0-9_%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            MatchCollection matchesEmail = regexEmail.Matches(NewUser.Email);
            Regex regaxPassword = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()_+{}\[\]:;'""<>,.?/~\\-]).{6,}$");
            MatchCollection matchesPassword = regaxPassword.Matches(NewUser.Password);

            if (NewUser.Password != RepeatPassword)
            {
                IsWrongRepeatPassword = true;
                IsCreatedNewUser = false;
                IsWrongEmail = false;
                IsWrongRegexPassword = false;
            }
            else if (matchesEmail.Count != 1)
            {
                IsWrongEmail = true;
                IsWrongRepeatPassword = false;
                IsCreatedNewUser = false;
                IsWrongRegexPassword = false;
            }
            else if (matchesPassword.Count != 1)
            {
                IsWrongRegexPassword = true;
                IsWrongEmail = false;
                IsWrongRepeatPassword = false;
                IsCreatedNewUser = false;
            }
            else
            {
                switch (SelectedRolesForUser.Name) {
                    case "Жюри":
                        NewUser.IdRoleNavigation = SelectedRolesForUser;
                        MainWindowViewModel.Instance.Dbcontext.Users.Add(NewUser);
                        MainWindowViewModel.Instance.Dbcontext.SaveChanges();
                        JuryDirection juryDirection = new JuryDirection()
                        {
                            IdUserJury = NewUser.Id,
                            IdDirectionNavigation = SelectedDirectionForUser
                        };
                        MainWindowViewModel.Instance.Dbcontext.JuryDirections.Add(juryDirection);
                        MainWindowViewModel.Instance.Dbcontext.SaveChanges();
                        IsCreatedNewUser = true;
                        break;
                    case "Модератор":
                        NewUser.IdRoleNavigation = SelectedRolesForUser;
                        MainWindowViewModel.Instance.Dbcontext.Users.Add(NewUser);
                        MainWindowViewModel.Instance.Dbcontext.SaveChanges();
                        ModeratorsDirectionsEvent moderatorsDirectionsEvent = new ModeratorsDirectionsEvent()
                        {
                            IdUserModerator = NewUser.Id,
                            IdDirectionNavigation = SelectedDirectionForUser,
                            IdTypeEvent = (int)SelectedEventForUser.IdTypeEvent
                        };
                        MainWindowViewModel.Instance.Dbcontext.ModeratorsDirectionsEvents.Add(moderatorsDirectionsEvent);
                        MainWindowViewModel.Instance.Dbcontext.SaveChanges();
                        IsCreatedNewUser = true;
                        break;
                }
            }
        }
        /// <summary>
        /// Open manager page
        /// </summary>
        public void ToManager()
        {
            MainWindowViewModel.Instance.Uc = new Manager(_currentUser);
        }
    }
}