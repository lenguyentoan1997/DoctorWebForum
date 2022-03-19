using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorsWebForum.Models.Forum
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("ApplicationUser")]
        [MaxLength(128)]
        public string AccountId { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }

        [ForeignKey("Answer")]
        public int AnswerId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Post Post { get; set; }

        public virtual Answer Answer { get; set; }
    }
}