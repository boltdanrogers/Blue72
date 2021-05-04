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
    [Authorize] // Allows you to use CommentService in the following methods
        public class CommentController : ApiController
        {
            private CommentService CreateCommentService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var commentService = new CommentService(userId);
                return commentService;
            }

        // Get all comments
        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetComments();
            return Ok(comments);
        }

        // Check comment is posted successfully
        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }

        // Get the comment by specific id
        public IHttpActionResult Get(int id)
        {
            CommentService commentService = CreateCommentService();
            var comment = commentService.GetCommentById(id);
            return Ok(comment);
        }

        // Checks if comment has been updated or not
        public IHttpActionResult Put(CommentEdit comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.UpdateComment(comment))
                return InternalServerError();

            return Ok();
        }

        // Checks if comment is deleted successfully or not
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCommentService();

            if (!service.DeleteComment(id))
                return InternalServerError();

            return Ok();
        }
    }
    
}
