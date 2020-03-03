using _24Hour.Services;
using ClassLibrary2;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24HourProject.Controllers
{
    public class LikeController : ApiController
    {
        public IHttpActionResult Post(CreateLike model)
        {
            if (this.ModelState.IsValid)
                return BadRequest();
            
            var service = CreateLikeService();

            if (!service.CreateLike(model))
                return InternalServerError();

            return Ok();
        }

        private LikeService CreateLikeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new LikeService(userId);
            return noteService;
        }
    }
}
