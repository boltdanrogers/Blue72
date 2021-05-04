using Blue72.Data;
using Blue72.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue72.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {

            _userId = userId;

        }//end of constructor

        //now start with a create method
        //have it return a bool to indicate success or failure
        public bool CreatePost(PostCreate model)// we re given a model of type PostCreate
        {
            var entity =
                new Post()
                {//use the postCreate model to provide most of the values for a new Post
                    //set title, text and authorId
                    Title = model.Title,
                    Text = model.Text,
                    AuthorId = _userId


                };//end of new post
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);//add the entity to the context
                return ctx.SaveChanges() == 1;//return whatever saving the entity to the actually database returns, 1 for success and 0 for failure

            }//end of using applicationDbContext

        }//end of method CreatePost

        //and now a method to get all Posts belonging to a specific user
        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.AuthorId == _userId)
                        .Select(
                            e =>
                                new PostListItem
                                {
                                    PostId = e.PostId,
                                    Title = e.Title,
                                }
                                );//end of select
                
                return query.ToArray();

            }//end of using 


        }//end of method getPosts














    }//end of class PostService
}
