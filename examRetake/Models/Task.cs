using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace examRetake.Models
{
    [Table("Tasks")]
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TaskAssignment> TaskAssignments { get; set; }
    }
}