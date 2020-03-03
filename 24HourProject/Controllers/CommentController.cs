﻿using _24Hour.Services;
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
    public class CommentController : ApiController
    {
        /*public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetCommentByPostId();
            return Ok(comments);
        }*/
        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }
        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userId);
            return commentService;
        }
        public IHttpActionResult Get(string id)
        {
            CommentService commentService = CreateCommentService();
            var comment = commentService.GetCommentByPostId(id);
            return Ok(comment);
        }
    }
}
