using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using YP.Models;
using YP.Models.DTO;
using YP.Views;

namespace YP.ViewModels
{
	public class NoAuthorizathionPageViewModel : ReactiveObject
	{
		List<Event> _listEvents = new List<Event>();
        List<EventDTO> _listEventsDTO = new List<EventDTO>();
        List<EventDTO> _listEventsDTOFull = new List<EventDTO>();

        List<TypesEvent> _listDirections = new List<TypesEvent>();
        TypesEvent _selectedDirection;
        string _searchData;

        public List<Event> ListEvents { get => _listEvents; set => this.RaiseAndSetIfChanged(ref _listEvents, value); }
        public List<EventDTO> ListEventsDTO { get => _listEventsDTO; set => this.RaiseAndSetIfChanged(ref _listEventsDTO, value); }
        public List<TypesEvent> ListDirections { get => _listDirections; set => this.RaiseAndSetIfChanged(ref _listDirections, value); }
        public TypesEvent SelectedDirection { get => _selectedDirection; set { this.RaiseAndSetIfChanged(ref _selectedDirection, value); AllFilters(); } }
        public string SearchData { get => _searchData; set { this.RaiseAndSetIfChanged(ref _searchData, value); AllFilters(); } }

        public NoAuthorizathionPageViewModel()
		{
			_listEvents = MainWindowViewModel.Instance.Dbcontext.Events.Include(x => x.IdTypeEventNavigation).ToList();
            foreach (var item in _listEvents)
            {
                EventDTO eventDTO = new EventDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Days = item.Days,
                    IdCity = item.IdCity,
                    IdTypeEvent = item.IdTypeEvent,
                    Image = item.Image,
                    IdCityNavigation = item.IdCityNavigation,
                    IdTypeEventNavigation = item.IdTypeEventNavigation,
                    ModeratorsDirectionsEvents = item.ModeratorsDirectionsEvents,
                    ScheduleEvents = item.ScheduleEvents
                };
            
                eventDTO.Image = @"avares://YP/Assets/events/" + eventDTO.Image;
              
                eventDTO.ImagePath = new Bitmap(AssetLoader.Open(new Uri(eventDTO.Image)));
                eventDTO.DateStart = new DateTimeOffset(item.DateStart.ToDateTime(new TimeOnly(0)));
                _listEventsDTO.Add(eventDTO);
            }
            _listDirections = MainWindowViewModel.Instance.Dbcontext.TypesEvents.ToList();
            _listEventsDTOFull = new List<EventDTO>(_listEventsDTO);
        }
        public void AllFilters()
        {
            SearchByData();
            FilterByDirection();
        }
        public void SearchByData()
        {
            switch (String.IsNullOrEmpty(SearchData))
            {
                case true:
                    ListEventsDTO = _listEventsDTOFull;
                    break;
                case false:
                    ListEventsDTO = _listEventsDTOFull.Where(x => x.DateStart.ToString("D").Contains(SearchData)).ToList();
                    break;
            }
        }
        public void FilterByDirection()
        {
            switch (SelectedDirection == null)
            {
                case false:
                    ListEventsDTO = ListEventsDTO.Where(x => x.IdTypeEventNavigation == SelectedDirection).ToList();
                    break;
            }
        }
        public void ToAuth()
        {
            FileInfo fileWithUserDate = new FileInfo("date_user.txt");
            if (fileWithUserDate.Exists)
            {
                using (FileStream fstream = File.OpenRead("date_user.txt"))
                {
                    // выделяем массив для считывания данных из файла
                    byte[] buffer = new byte[fstream.Length];
                    // считываем данные
                    fstream.Read(buffer, 0, buffer.Length);
                    // декодируем байты в строку
                    string textFromFile = Encoding.Default.GetString(buffer);
                    List<string> parseDateUser = textFromFile.Split(" ").ToList();
                    User currentUser = MainWindowViewModel.Instance.Dbcontext.Users.FirstOrDefault(x => x.Id == Convert.ToInt32(parseDateUser[0]) && x.Password == parseDateUser[1]);
                    switch (currentUser.IdRole)
                    {
                        case 3:
                            
                            MainWindowViewModel.Instance.Uc = new Manager(currentUser);
                            break;
                    }
                }
            }

            else
            {
                MainWindowViewModel.Instance.Uc = new Authorizathion();

            }
        }
        
    }
}