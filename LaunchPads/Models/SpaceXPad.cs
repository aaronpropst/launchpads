using System;
using Newtonsoft.Json;

namespace LaunchPads.Models
{
    /// <summary>
    /// SpaceX's Launchpad Model
    /// </summary>
    public class SpaceXPad
    {
        public Pad ToPad()
        {
            return new Pad
            {
                Name = Name,
                Id = Id,
                Status = Status
            };
        }


        [JsonProperty(PropertyName = "full_name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }



        [JsonProperty(PropertyName = "attempted_launches")]
        public int AttemptedLaunches { get; set; }

        [JsonProperty(PropertyName = "details")]
        public string Details { get; set; }

        [JsonProperty(PropertyName = "location")]
        public SpaceXPadLocation Location { get; set; }

        [JsonProperty(PropertyName = "padid")]
        public int Padid { get; set; }

        [JsonProperty(PropertyName = "successful_launches")]
        public int SuccessfulLaunches { get; set; }

        [JsonProperty(PropertyName = "vehicles_launched")]
        public string[] VehiclesLaunched { get; set; }

        [JsonProperty(PropertyName = "wikipedia")]
        public string Wikipedia { get; set; }


    }


    public class SpaceXPadLocation
    {
        [JsonProperty(PropertyName = "lattitude")]
        public float Lattitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public float Longitude { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }
    }
}
