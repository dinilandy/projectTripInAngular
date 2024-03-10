using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface Icontext
    {
            public DbSet<OrderPlace> OrderPlaces { get; set; }
            public DbSet<TheTrip> Trips { get; set; }
            public DbSet<TypesTrip> TypesTrips { get; set; }
            public DbSet<User> Users { get; set; }

            Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        
    }
}
