using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;

namespace PruebaTecnica.Core.Interfaces
{
    public interface IPostReposity
    {
        public Task<IEnumerable<Post>> GetPosts();
        public Task<Post> GetPost(int id);
        public Task InsertPost(Post post);
        public Task<bool> UpdatePost(Post post);
        public Task<bool> DeletePost(int id);

    }
}
