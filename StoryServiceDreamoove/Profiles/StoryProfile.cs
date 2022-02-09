using AutoMapper;
using StoryServiceDreamoove.Dtos;
using StoryServiceDreamoove.Models;

namespace StoryServiceDreamoove.Profiles
{
    public class StoryProfile : Profile
    {
        public StoryProfile()
        {
            CreateMap<Story, StoryReadDto>();
            CreateMap<StoryCreateDto, Story>();
            CreateMap<StoryUpdateDto, Story>();

            CreateMap<UserCreateDto, User>();
        }
    }
}