using examRetake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace examRetake.ViewModel
{
    public class TaskAssignmentViewModel
    {
        public int TaskId;
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public List<Users> UsersList;
    }
}