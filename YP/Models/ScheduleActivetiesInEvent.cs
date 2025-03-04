using System;
using System.Collections.Generic;

namespace YP.Models;

public partial class ScheduleActivetiesInEvent
{
    public int Id { get; set; }

    public int IdActivity { get; set; }

    public TimeOnly TimeStart { get; set; }

    public int Day { get; set; }

    public int IdScheduleEvent { get; set; }

    public int? IdModeratorUser { get; set; }

    public virtual Activety IdActivityNavigation { get; set; } = null!;

    public virtual User? IdModeratorUserNavigation { get; set; }

    public virtual ScheduleEvent IdScheduleEventNavigation { get; set; } = null!;

    public virtual ICollection<ScheduleActivetiesJury> ScheduleActivetiesJuries { get; set; } = new List<ScheduleActivetiesJury>();
}
