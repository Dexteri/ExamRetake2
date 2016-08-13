using examRetake.Models;
using examRetake.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace examRetake.Controllers
{
    public class StudentController : Controller
    {
        private StudentService studentService = new StudentService();
        private TaskService service = new TaskService();
        // GET: Student
        public ActionResult Index()
        {
            return View(this.studentService.GetTask());
        }
        public ActionResult Details(int id)
        {
            Task task = service.Details(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            this.studentService.ChangeStatus(id, Status.Started);
            return View(task);
        }
    }
}