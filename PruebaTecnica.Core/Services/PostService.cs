﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace PruebaTecnica.Core.Services
{
    public class PostService : IPostService
    {

        private readonly IPostReposity _postRepository;

        public PostService(IPostReposity postRepository)
        {
            _postRepository = postRepository;
        }


        public async Task<bool> DeletePost(int id)
        {
            return await _postRepository.DeletePost(id);
        }

        public async Task<Post> GetPost(int id)
        {
            return await _postRepository.GetPost(id);
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _postRepository.GetPosts();
        }

        public async Task InsertPost(Post post)
        {
            await _postRepository.InsertPost(post);
        }

        public async Task<bool> UpdatePost(Post post)
        {
            return await _postRepository.UpdatePost(post);
        }

    }
}
