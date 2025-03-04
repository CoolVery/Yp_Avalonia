using System;
using System.Collections.Generic;

namespace YP.Models;

public partial class Event
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly DateStart { get; set; }

    public int Days { get; set; }

    public int IdCity { get; set; }

    public int? IdTypeEvent { get; set; }

    public string? Image { get; set; }

    public virtual City IdCityNavigation { get; set; } = null!;

    public virtual TypesEvent? IdTypeEventNavigation { get; set; }

    public virtual ICollection<ModeratorsDirectionsEvent> ModeratorsDirectionsEvents { get; set; } = new List<ModeratorsDirectionsEvent>();

    public virtual ICollection<ScheduleEvent> ScheduleEvents { get; set; } = new List<ScheduleEvent>();
}
