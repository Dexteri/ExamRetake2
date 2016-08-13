using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace examRetake.Models
{
    [Table("Request")]
    public class Request
    {
        [Key]
        public int ID { get; set; }
        public int TaskAssignID { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Comment { get; set; }

        public virtual TaskAssignment TaskAssignments { get; set; }

    }
}