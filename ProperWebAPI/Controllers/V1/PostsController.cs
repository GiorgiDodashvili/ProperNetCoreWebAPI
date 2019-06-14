using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProperWebAPI.Contract.V1;
using ProperWebAPI.Contract.V1.Requests;
using ProperWebAPI.Contract.V1.Response;
using ProperWebAPI.Domain;

namespace ProperWebAPI.Controllers
{
    public class PostsController : Controller
    {
        private readonly List<Post> posts;

        public PostsController()
        {
            this.posts = new List<Post>();
            for (int i = 0; i < 5; i++)
            {
                posts.Add(new Post
                {
                    Id = Guid.NewGuid(),
                    Name = $"Post Name {i}"
                });
            }
        }
        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(posts);
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public IActionResult Get([FromRoute]Guid PostId)
        {
            var post = posts.SingleOrDefault(x => x.Id == PostId);

            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postRequest)
        {
            var post = new Post { Id = postRequest.Id };
             
            if (post.Id != Guid.Empty) post.Id = Guid.NewGuid();
            

            posts.Add(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString());

            var response = new PostResponse { Id = post.Id };
            return Created(locationUri, response);
        }
    }
}