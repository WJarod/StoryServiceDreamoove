using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoryServiceDreamoove.Models;

namespace StoryServiceDreamoove.Data
{
    public class StoryRepo : IStoryRepo
    {
        private readonly AppDbContext _context;

        public StoryRepo (AppDbContext context){ _context = context; }

        public void CreateStory(Story story)
        {
            if (story == null)
            {
                throw new ArgumentNullException(nameof(story));
            }

            _context.Add(story);
            _context.SaveChanges();
        }

        public void DeleteStory(int id)
        {
            var story = _context.Story.FirstOrDefault( story => story.Id == id);

            if (story != null)
            {
                _context.Story.Remove(story);
            }
        }

        public IEnumerable<Story> GetAllStory()
        {
            _context.User.ToList();
            return _context.Story.ToList();
        }

        public IEnumerable<Story> GetAllStoryByUserId(int id)
        {
            _context.User.ToList();
            return _context.Story.Where(story => story.UserId == id).ToList();
        }

        public Story GetStory(int id)
        {
            _context.User.ToList();
            return _context.Story.FirstOrDefault(story => story.Id == id);
        }

        public User GetUserById(int id)
        {
            return _context.User.FirstOrDefault(user => user.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0 );
        }

        public void UpdateStory(int id)
        {
            var story = _context.Story.FirstOrDefault( story => story.Id == id);

            _context.Entry(story).State = EntityState.Modified;
        }
    }
}