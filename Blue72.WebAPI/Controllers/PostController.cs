using Blue72.Models;
using Blue72.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blue72.WebAPI.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        //this method creates a PostService
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;

        }//end of method CreatePostService

        //this is our get all method
        public IHttpActionResult Get()
        {

            PostService postService = CreatePostService();
            var posts = postService.GetPosts();
            return Ok(posts);

        }//end of method Get

        //now a post post method *hahaha*
        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }//end of if model state is valid

            //create a post service
            var service = CreatePostService();

            if (!service.CreatePost(post))
            {
                return InternalServerError();
            }//end of if

            return Ok();

        }//end of Post method




    }//end of PostController
}
