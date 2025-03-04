using System;
using System.Collections.Generic;

namespace YP.Models;

public partial class JuryDirection
{
    public int Id { get; set; }

    public int IdUserJury { get; set; }

    public int IdDirection { get; set; }

    public virtual Direction IdDirectionNavigation { get; set; } = null!;

    public virtual User IdUserJuryNavigation { get; set; } = null!;
}
