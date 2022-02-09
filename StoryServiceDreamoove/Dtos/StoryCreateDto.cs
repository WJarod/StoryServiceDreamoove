using System.ComponentModel.DataAnnotations;
using StoryServiceDreamoove.Models;

namespace StoryServiceDreamoove.Dtos
{
    public class StoryCreateDto
    {
        [Required]
        public string Video { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}