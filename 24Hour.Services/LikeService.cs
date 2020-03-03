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
    public class LikeService
    {
        Guid _userId;

        public LikeService(Guid userId)
        {
            _userId = userId;
        }
        
        public bool CreateLike(CreateLike model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(new Like
                {
                    PostId = model.PostId,
                    UserId = _userId
                });

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
