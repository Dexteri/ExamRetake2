using examRetake.Account_Manager.Service;
using examRetake.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace examRetake.Service
{
    public class StudentService
    {
        public static bool IsAdmin = false;

        private examRetakeContext db;
        private UserManagingService user_service;
        private int userID;
        public StudentService()
        {
            db = new examRetakeContext();
            user_service = new UserManagingService();
            userID = user_service.GetUserID();
        }
        public List<Task> GetTask()
        {
            var tasksAssig = getListTasksAssig();
            if (tasksAssig != null)
            {
                List<Task> tasks = new List<Task>();
                foreach (int id in tasksAssig)
                {
                    Task t = db.Tasks.Find(id);
                    tasks.Add(t);
                }
                    
                return tasks;
            }
            return null;
        }
        private List<int> getListTasksAssig(int userID =-1)
        {
            var user = userID == -1 ? this.userID : userID;
            return db.TaskAssignments.Where(x => x.UserID == user).Select(x => x.TaskID).ToList();
        }
        public void ChangeStatus(int taskID, Status status)
        {
            TaskAssignment task = db.TaskAssignments.Where(x => x.TaskID == taskID && x.UserID == this.userID).FirstOrDefault();
            task.Status = status.ToString();
            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void ClickHelp(int taskID)
        {
            //ID, TaskAssignID, Status: New, Type: Help
            int taskAssignID = db.TaskAssignments.Where(x => x.TaskID == taskID && x.UserID == this.userID).Select(x => x.ID).FirstOrDefault();
            Request req = new Request();
            req.TaskAssignID = taskAssignID;
            req.Status = Status.New.ToString();
            req.Type = TypeReq.Help.ToString();
            db.Requests.Add(req);
            db.SaveChanges();

        }
        private bool isAdmin()
        {
            return db.Users.Find(this.userID).Role.Equals("admin");
        }
    }
}