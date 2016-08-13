using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using examRetake.Models;

namespace examRetake.ViewModel
{
    public class ViewModelClass
    {
        [Key]
        public Student Student { get; set; }
        public Task Task { get; set; }
    }
}