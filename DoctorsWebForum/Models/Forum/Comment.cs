using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorsWebForum.Models.Forum
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public string DateTime { get; set; }

        [ForeignKey("ApplicationUser")]
        [MaxLength(128)]
        public string AccountId { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Post Post { get; set; }

        public virtual ICollection<CommentChild> CommentChilds { get; set; }
    }
}