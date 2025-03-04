using System;
using System.Collections.Generic;

namespace YP.Models;

public partial class User
{
    public int Id { get; set; }

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly Birthday { get; set; }

    public string Phone { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public int IdGender { get; set; }

    public int IdCountry { get; set; }

    public int IdRole { get; set; }

    public string FullName { get; set; } = null!;

    public string? Image { get; set; }

    public virtual Country IdCountryNavigation { get; set; } = null!;

    public virtual Gender IdGenderNavigation { get; set; } = null!;

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<JuryDirection> JuryDirections { get; set; } = new List<JuryDirection>();

    public virtual ICollection<ModeratorsDirectionsEvent> ModeratorsDirectionsEvents { get; set; } = new List<ModeratorsDirectionsEvent>();

    public virtual ICollection<ScheduleActivetiesInEvent> ScheduleActivetiesInEvents { get; set; } = new List<ScheduleActivetiesInEvent>();

    public virtual ICollection<ScheduleActivetiesJury> ScheduleActivetiesJuries { get; set; } = new List<ScheduleActivetiesJury>();

    public virtual ICollection<ScheduleEvent> ScheduleEvents { get; set; } = new List<ScheduleEvent>();
}
