using System;
using System.Collections.Generic;
using System.Linq;
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
		List<Event> listEvents = new List<Event>();
        List<EventDTO> listEventsDTO = new List<EventDTO>();

        public List<Event> ListEvents { get => listEvents; set => this.RaiseAndSetIfChanged(ref listEvents, value); }
        public List<EventDTO> ListEventsDTO { get => listEventsDTO; set => this.RaiseAndSetIfChanged(ref listEventsDTO, value); }

        public NoAuthorizathionPageViewModel()
		{
			listEvents = MainWindowViewModel.Instance.Dbcontext.Events.Include(x => x.IdTypeEventNavigation).ToList();
            foreach (var item in listEvents)
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
                ///Assets/avalonia-logo.ico
                ///"C:\Users\Admin\source\repos\Yp_Avalonia\YP\Assets\events\1.jpeg"
                eventDTO.Image = @"avares://YP/Assets/events/" + eventDTO.Image;
              
                eventDTO.ImagePath = new Bitmap(AssetLoader.Open(new Uri(eventDTO.Image)));
                eventDTO.DateStart = new DateTimeOffset(item.DateStart.ToDateTime(new TimeOnly(0)));
                listEventsDTO.Add(eventDTO);

            }
        }
        public void ToAuth()
        {
            MainWindowViewModel.Instance.Uc = new Authorizathion();
        }
        
    }
}