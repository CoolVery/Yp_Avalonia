using System;
using System.Collections.Generic;

namespace YP.Models;

public partial class Activety
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ScheduleActivetiesInEvent> ScheduleActivetiesInEvents { get; set; } = new List<ScheduleActivetiesInEvent>();
}
