using System.ComponentModel.DataAnnotations;
using StoryServiceDreamoove.Models;

namespace StoryServiceDreamoove.Dtos
{
    public class StoryUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Video { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}