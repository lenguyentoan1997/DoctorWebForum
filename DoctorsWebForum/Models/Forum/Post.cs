using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorsWebForum.Models.Forum
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public string DateTime { get; set; }

        public string Status { get; set; }

        [ForeignKey("Expertise")]
        public int ExpertiseId { get; set; }

        [ForeignKey("ApplicationUser")]
        [MaxLength(128)]
        public string AccountId { get; set; }

        [ForeignKey("Type")]
        public int TypeId { get; set; }

        public virtual Expertise Expertise { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Type Type { get; set; }

        public virtual ICollection<Emoticon> Emoticons { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual Answer Answer { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}