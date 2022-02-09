using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StoryServiceDreamoove.Data;
using StoryServiceDreamoove.Dtos;
using StoryServiceDreamoove.Models;

namespace StoryServiceDreamoove.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoryController : ControllerBase
    {
        private readonly IStoryRepo _repository;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public StoryController(IMapper mapper, IStoryRepo repository, HttpClient httpClient, IConfiguration configuration)
        { 
            _repository = repository;
            _mapper = mapper;
            _httpClient = httpClient; 
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StoryReadDto>> GetAllStory()
        {
            var storyItems = _repository.GetAllStory();

            return Ok(_mapper.Map<IEnumerable<StoryReadDto>>(storyItems));
        }

        [HttpGet("{id}", Name = "GetStory")]
        public ActionResult<StoryReadDto> GetStory(int id)
        {
            var storyItem = _repository.GetStory(id);

            return Ok(_mapper.Map<StoryReadDto>(storyItem));
        }

        [HttpGet("user/{id}", Name = "GetAllStoryByUserId")]
        public ActionResult<IEnumerable<StoryReadDto>>  GetAllStoryByUserId(int id)
        {
            var storyItems = _repository.GetAllStoryByUserId(id);

            return Ok(_mapper.Map<IEnumerable<StoryReadDto>>(storyItems));
        }

        [HttpPost]
        public async Task<ActionResult<StoryCreateDto>> CreateStory(StoryCreateDto storyCreateDto)
        {
            var storyModel = _mapper.Map<Story>(storyCreateDto);
            
            if (storyModel == null)
            {
                return NotFound();
            }

            var getUser = await _httpClient.GetAsync($"{_configuration["Userservice"]}" + storyModel.UserId);

            var userItem = JsonConvert.DeserializeObject<UserCreateDto>(
                await getUser.Content.ReadAsStringAsync());

            var UserModel = _mapper.Map<User>(userItem);

            var user = _repository.GetUserById(UserModel.Id); 

            if(user == null)storyModel.User = UserModel;else storyModel.User = user;
            
            _repository.CreateStory(storyModel);
            _repository.SaveChanges();

            var storyReadDto = _mapper.Map<StoryReadDto>(storyModel);

            return CreatedAtRoute(nameof(GetStory), new { Id = storyReadDto.Id }, storyReadDto);
        }

        [HttpPut("{id}", Name = "UpdateStory")]
        public ActionResult<StoryReadDto> UpdateStory(int id, StoryUpdateDto storyUpdateDto)
        {
            var storyModel = _repository.GetStory(id);

            _mapper.Map(storyUpdateDto, storyModel);
            
            if (storyModel == null)
            {
                return NotFound();
            }
            _repository.UpdateStory(storyModel.Id);
            _repository.SaveChanges();

            var storyReadDto = _mapper.Map<StoryReadDto>(storyModel);
            
            return CreatedAtRoute(nameof(GetStory), new { Id = storyModel.Id }, storyReadDto);
        }

        [HttpDelete("{id}")]
        public ActionResult<StoryReadDto> DeleteStory(int id)
        {
            var story = _repository.GetStory(id);

            if (story == null)return NotFound(); else _repository.DeleteStory(story.Id); _repository.SaveChanges(); return Ok(_mapper.Map<StoryReadDto>(story));
        }
    }
}