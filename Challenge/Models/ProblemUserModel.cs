using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Challenge.Models
{
    public class ProblemUserModel
    {
        [Key, Column(Order = 1)]
        public int ProblemFK { get; set; }

        public virtual Problem Problem { get; set; }

        [Key, Column(Order = 2)]
        public string UserFK { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Solution { get; set; }
    }
}