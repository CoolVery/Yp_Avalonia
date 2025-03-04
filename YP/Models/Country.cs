using System;
using System.Collections.Generic;

namespace YP.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string EnName { get; set; } = null!;

    public string Code { get; set; } = null!;

    public int CodeSecond { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
