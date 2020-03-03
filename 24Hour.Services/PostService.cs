using _24HourProject.Data;
using ClassLibrary1;
using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    UserId = _userId,
                    Title = model.Title,
                    Text = model.Text,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PostListOfItems> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new PostListOfItems
                                {
                                    PostId = e.PostId,
                                    Title = e.Title,
                                }
                        );
                return query.ToArray();
            }
        }
        public PostDetail GetPostById(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == id && e.UserId == _userId);
                return
                    new PostDetail
                    {
                        PostId = entity.PostId,
                        Title = entity.Title,
                        Text = entity.Text,
                    };
            }
        }
    }
}
