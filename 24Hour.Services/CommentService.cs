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
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    UserId = _userId,
                    Text = model.Text,
                    PostId = model.PostId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListOfItems>GetCommentByPostId(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Where(e => e.PostId == id)
                        .Select(
                            e =>
                                new CommentListOfItems
                                {
                                    PostId = e.PostId,
                                    Text = e.Text,
                                }
                              );
                return entity.ToArray();
            }
        }
    }
}
