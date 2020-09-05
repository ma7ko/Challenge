using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Challenge.Models
{
    public class Challenge
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Created on")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Ends on")]
        public DateTime EndsOn { get; set; }

        public virtual ICollection<ApplicationUser> Participants { get; set; }

        public virtual ICollection<Problem> Problems { get; set; }
    }
}