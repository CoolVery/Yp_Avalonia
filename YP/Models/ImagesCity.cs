using System;
using System.Collections.Generic;

namespace YP.Models;

public partial class ImagesCity
{
    public int Id { get; set; }

    public int IdCity { get; set; }

    public string? Image { get; set; }

    public virtual City IdCityNavigation { get; set; } = null!;
}
