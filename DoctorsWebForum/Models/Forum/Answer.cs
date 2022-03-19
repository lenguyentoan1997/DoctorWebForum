using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorsWebForum.Models.Forum
{
    public class Answer
    {
        [Key]
        [ForeignKey("Post")]
        public int Id { get; set; }

        public string Content { get; set; }

        public string DateTime { get; set; }

        [ForeignKey("Doctor")]
        [MaxLength(128)]
        public string DoctorId { get; set; }

        public virtual Post Post { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}