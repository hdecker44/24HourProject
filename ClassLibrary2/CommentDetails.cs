﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    class CommentDetails
    {
        public string PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public User Author { get; set; }
        public Post CommentPost { get; set; }

    }
}
