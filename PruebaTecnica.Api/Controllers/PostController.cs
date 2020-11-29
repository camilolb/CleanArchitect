
namespace PruebaTecnica.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Pruebatecnica.Infraestructura.Repositories;
    using PruebaTecnica.Core.DTOs;
    using PruebaTecnica.Core.Entities;
    using PruebaTecnica.Core.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostReposity _postReposity;
        private readonly IMapper _mapper;

        public PostController(IPostReposity postReposity, IMapper mapper)
        {
            _postReposity = postReposity;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var post = await _postReposity.GetPosts();
            var postDto = _mapper.Map<IEnumerable<PostDto>>(post);
            return Ok(postDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postReposity.GetPost(id);
            var postDto = _mapper.Map<PostDto>(post);
            return Ok(postDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postReposity.InsertPost(post);

            return Ok(postDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.PostId = id;
            var result = await _postReposity.UpdatePost(post);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postReposity.DeletePost(id);
            return Ok(result);
        }

    }
}