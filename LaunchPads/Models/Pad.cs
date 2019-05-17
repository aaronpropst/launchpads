using Newtonsoft.Json;

namespace LaunchPads.Models
{
    /// <summary>
    /// Our Launchpad Model.  A stripped down version of the spacex one.
    /// </summary>
    public class Pad{
        public string Name { get; set; }
        public string Id { get; set; }
        public string Status { get; set; }
    }

}
