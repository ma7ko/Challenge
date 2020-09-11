using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Challenge.Models
{
    public class Problem
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ChallengeFK { get; set; }

        public virtual Challenge Challenge { get; set; }

        public virtual ICollection<ProblemUserModel> Solutions { get; set; }

    }
}