using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey(nameof(CommentPost))]
        public string PostId { get; set; }
        public Post CommentPost { get; set; }

    }
}
