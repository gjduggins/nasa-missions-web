using System.ComponentModel.DataAnnotations;

namespace NASA.Missions.Web.Models
{
    public class MissionViewModel
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Mission Name")]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Launch Date")]
        public DateTime LaunchDate { get; set; }
        
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        
        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; } = string.Empty;
        
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Agency")]
        public string Agency { get; set; } = "NASA";
        
        [Required]
        [Display(Name = "Mission Type")]
        public string Type { get; set; } = string.Empty;
    }
}