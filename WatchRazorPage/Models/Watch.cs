using System.ComponentModel.DataAnnotations;

namespace WatchRazorPage.Models
{
    public class Watch
    {
        public int Id { get; set; }
        [Display(Name = "Brand Name")]
        [Required]
        public string? BrandName { get; set; }
        [Display(Name = "Model Name")]
        [Required]
        public string? ModelName { get; set; }
        [Display(Name = "Model Reference")]
        [Required]
        public string? ModelReference { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        
    }
}
