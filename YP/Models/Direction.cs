using System;
using System.Collections.Generic;

namespace YP.Models;

public partial class Direction
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<JuryDirection> JuryDirections { get; set; } = new List<JuryDirection>();

    public virtual ICollection<ModeratorsDirectionsEvent> ModeratorsDirectionsEvents { get; set; } = new List<ModeratorsDirectionsEvent>();
}
