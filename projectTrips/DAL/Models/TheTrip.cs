using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class TheTrip
{
    public short IdTrip { get; set; }

    public string TargetTripe { get; set; } = null!;

    public short IdType { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? LeavingTime { get; set; }

    public short? DurationTripInHours { get; set; }

    public short? NumberPlacesAvailable { get; set; }

    public short? Price { get; set; }

    public string? Image { get; set; }

    public virtual TypesTrip IdTypeNavigation { get; set; } = null!;

    public virtual ICollection<OrderPlace> OrderPlaces { get; set; } = new List<OrderPlace>();
}
