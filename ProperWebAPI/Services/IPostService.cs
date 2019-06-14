using ProperWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProperWebAPI.Services
{
    interface IPostService
    {
        List<Post> GetPosts();

        PostService GetPostById(Guid postId);
    }
}
