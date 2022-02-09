using System.Collections.Generic;
using StoryServiceDreamoove.Models;

namespace StoryServiceDreamoove.Data
{
    public interface IStoryRepo
    {
        bool SaveChanges();

        void CreateStory(Story story);

        IEnumerable<Story> GetAllStory();

        Story GetStory(int id);

        User GetUserById(int id);

        IEnumerable<Story> GetAllStoryByUserId(int id);

        void DeleteStory(int id);

        void UpdateStory(int id);
    }
}