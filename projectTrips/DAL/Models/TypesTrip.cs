using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class TypesTrip
{
    public short IdType { get; set; }

    public string? NameType { get; set; }

    public virtual ICollection<TheTrip> TheTrips { get; set; } = new List<TheTrip>();
}
