using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorsWebForum.Models.Forum
{
    public class Doctor
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        [MaxLength(128)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string DOB { get; set; }

        public string Gender { get; set; }

        public string Workplace { get; set; }

        public string Qualification { get; set; }

        public string Achievement { get; set; }

        public string DateCreate { get; set; }

        public string Confirm { get; set; }

        [ForeignKey("Expertise")]
        public int ExpertiseId { get; set; }

        public virtual Expertise Expertise { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}