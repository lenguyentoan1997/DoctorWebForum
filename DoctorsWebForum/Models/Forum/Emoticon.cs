using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorsWebForum.Models.Forum
{
    public class Emoticon
    {
        [Key]
        public int Id { get; set; }

        public string Status { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }

        [ForeignKey("ApplicationUser")]
        [MaxLength(128)]
        public string AccountId { get; set; }

        public virtual Post Post { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}