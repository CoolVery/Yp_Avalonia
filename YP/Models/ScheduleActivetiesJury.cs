using System;
using System.Collections.Generic;

namespace YP.Models;

public partial class ScheduleActivetiesJury
{
    public int Id { get; set; }

    public int IdJuryUser { get; set; }

    public int IdScheduleActivity { get; set; }

    public virtual User IdJuryUserNavigation { get; set; } = null!;

    public virtual ScheduleActivetiesInEvent IdScheduleActivityNavigation { get; set; } = null!;
}
