using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TrackApi.Models;

namespace TrackApi
{
    public class TrackApiDbContext : DbContext
    {
        public TrackApiDbContext() : base("TrackApiContext")
        {
        }

        public DbSet<LocationData> Locations { get; set; }
    }
}