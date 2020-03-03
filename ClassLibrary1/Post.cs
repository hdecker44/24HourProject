using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Post
    {
        [Key]
        public string PostId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Text { get; set; }

        [ForeignKey(nameof(Author))]
        public Guid? UserId { get; set; }
        public virtual User Author { get; set; }

    }
}
