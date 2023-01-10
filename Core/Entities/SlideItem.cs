using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
	public class SlideItem
	{
		public int Id { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Price { get; set; }
        public string OldPrice { get; set; }

    }
}

