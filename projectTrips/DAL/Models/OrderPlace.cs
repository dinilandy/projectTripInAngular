using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class OrderPlace
{
    public short IdOrder { get; set; }

    public short? IdUser { get; set; }

    public DateTime? OrderDate { get; set; }

    public TimeSpan? OrderTime { get; set; }

    public short? IdTrip { get; set; }

    public short? NumberPlaces { get; set; }

    public virtual TheTrip? IdTripNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
