using System;
using System.Collections.Generic;

namespace YP.Models;

public partial class ScheduleEvent
{
    public int Id { get; set; }

    public int IdEvent { get; set; }

    public int Day { get; set; }

    public int? IdWinnerUser { get; set; }

    public virtual Event IdEventNavigation { get; set; } = null!;

    public virtual User? IdWinnerUserNavigation { get; set; }

    public virtual ICollection<ScheduleActivetiesInEvent> ScheduleActivetiesInEvents { get; set; } = new List<ScheduleActivetiesInEvent>();
}
