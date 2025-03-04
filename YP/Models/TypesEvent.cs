using System;
using System.Collections.Generic;

namespace YP.Models;

public partial class TypesEvent
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
