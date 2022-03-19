using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorsWebForum.Models.Forum
{
    public class Expertise
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}