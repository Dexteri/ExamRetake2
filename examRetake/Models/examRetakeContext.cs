using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace examRetake.Models
{
    public class examRetakeContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public examRetakeContext() : base("name=examRetakeContext")
        {
        }

        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<TaskAssignment> TaskAssignments { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
    }
}
