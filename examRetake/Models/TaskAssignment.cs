using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace examRetake.Models
{
    [Table("TaskAssignment")]
    public class TaskAssignment
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int TaskID { get; set; }
        public string Status { get; set; }

        public virtual Users User { get; set; }
        public virtual Task Tasks { get; set; }
    }
}