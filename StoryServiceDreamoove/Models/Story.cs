using System.ComponentModel.DataAnnotations;

namespace StoryServiceDreamoove.Models
{
    public class Story
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Video { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }
        
    }
}