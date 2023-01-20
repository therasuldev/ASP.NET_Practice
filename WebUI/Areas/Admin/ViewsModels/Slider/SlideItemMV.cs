using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.ViewsModels.Slider;

    public class SlideItemMV
    {
        public int Id { get; set; }
    [   Required]
        public string? Photo { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Price { get; set; }
        public string? OldPrice { get; set; }
    }


