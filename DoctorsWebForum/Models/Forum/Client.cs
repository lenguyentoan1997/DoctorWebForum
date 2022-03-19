using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorsWebForum.Models.Forum
{
    public class Client
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        [MaxLength(128)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string DOB { get; set; }

        public string Gender { get; set; }

        public string DateCreate { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}