using System.ComponentModel.DataAnnotations;
using StoryServiceDreamoove.Models;

namespace StoryServiceDreamoove.Dtos
{
    public class StoryReadDto
    {
        public int Id { get; set; }
        public string Video { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}