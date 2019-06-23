using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProperWebAPI.Data;
using ProperWebAPI.Domain;

namespace ProperWebAPI.Services
{
    public class PostService : IPostService
    {
        private readonly DataContext DB;

        public PostService(DataContext db)
        {
            DB = db;
        }
        public async Task<Post> GetPostByIdAsync(Guid postId)
        {
            return await DB.Posts.SingleOrDefaultAsync(s => s.Id == postId);
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await DB.Posts.ToListAsync();
        }

        public async Task<bool> UpdatePostAsync(Post postToUpdate)
        {
            DB.Posts.Update(postToUpdate);
            var updated = await DB.SaveChangesAsync();
            return updated>0;
        }

        public async Task<bool> DeletePostAsync(Guid postId)
        {
            var post = await GetPostByIdAsync(postId);
            DB.Remove(post);
            var deleted = await DB.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<bool> CreatePostAsync(Post postToAdd)
        {
            await DB.Posts.AddAsync(postToAdd);
            var created = await DB.SaveChangesAsync();
            return created > 0;
        }
    }
}
