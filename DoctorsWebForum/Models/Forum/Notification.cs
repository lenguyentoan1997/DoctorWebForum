using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorsWebForum.Models.Forum
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public string DateTime { get; set; }

        public string Status { get; set; }

        [ForeignKey("ApplicationUser")]
        [MaxLength(128)]
        public string AccountId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}