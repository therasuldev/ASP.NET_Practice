using System.ComponentModel.DataAnnotations;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Core.Entities
{
	public class SlideItem:IEntity
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

