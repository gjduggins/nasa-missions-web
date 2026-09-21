namespace NASA.Missions.Web.Models
{
    public class Mission
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime LaunchDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Agency { get; set; } = "NASA";
        public string Type { get; set; } = string.Empty;
        public bool IsActive => EndDate == null && Status.ToLower() != "failed";
    }
}