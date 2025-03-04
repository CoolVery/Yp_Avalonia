using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YP.Models.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTimeOffset DateStart { get; set; }

        public int Days { get; set; }

        public int IdCity { get; set; }

        public int? IdTypeEvent { get; set; }

        public string? Image { get; set; }
        public Bitmap ImagePath { get;  set; }

        public virtual City IdCityNavigation { get; set; } = null!;

        public virtual TypesEvent? IdTypeEventNavigation { get; set; }

        public virtual ICollection<ModeratorsDirectionsEvent> ModeratorsDirectionsEvents { get; set; } = new List<ModeratorsDirectionsEvent>();

        public virtual ICollection<ScheduleEvent> ScheduleEvents { get; set; } = new List<ScheduleEvent>();
    }
}
