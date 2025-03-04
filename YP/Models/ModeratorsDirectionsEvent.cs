using System;
using System.Collections.Generic;

namespace YP.Models;

public partial class ModeratorsDirectionsEvent
{
    public int Id { get; set; }

    public int IdUserModerator { get; set; }

    public int IdDirection { get; set; }

    public int IdTypeEvent { get; set; }

    public virtual Direction IdDirectionNavigation { get; set; } = null!;

    public virtual Event IdTypeEventNavigation { get; set; } = null!;

    public virtual User IdUserModeratorNavigation { get; set; } = null!;
}
