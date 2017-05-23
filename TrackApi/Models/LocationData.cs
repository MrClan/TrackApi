using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackApi.Models
{
    public class LocationData
    {
        public LocationData()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string DeviceIdentifier { get; set; }
        public DateTime LoggedTime { get; set; }
        public string LatLong { get; set; }
        public string AdditionalData { get; set; }

    }
}