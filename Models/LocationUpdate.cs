namespace LocationTracking_WebHook.Models
{
    public class LocationUpdate
    {
        public string? UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
