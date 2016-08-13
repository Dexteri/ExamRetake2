using examRetake.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace examRetake.Service
{
    public class TaskService
    {
        private examRetakeContext db;
        public TaskService()
        {
            this.db = new examRetakeContext();
        }
        public List<Task> GetListTask()
        {
            return db.Tasks.ToList();
        }
        public Task Details(int? id)
        {
            Task result = new Task();
            try
            {
                result = db.Tasks.Find(id);
            }
            catch
            {
                return null;
            }

            return result;
        }
        public void Create(Task task)
        {
            try
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            }
            catch { }
        }
        public void Edit(Task task)
        {
            try
            {
                if (task != null)
                {
                    db.Entry(task).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch { }
        }
        public void Delete(int id)
        {
            try
            {
                var task = db.Tasks.Find(id);
                if (task != null)
                {
                    db.Tasks.Remove(task);
                    db.SaveChanges();
                }
            }
            catch { }
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public bool AssignTaskToStudentID(int taskID, int userID)
        {
            if (!db.TaskAssignments.Any(x => x.TaskID == taskID && x.UserID == userID))
            {
                TaskAssignment taskAssignment;
                taskAssignment = new TaskAssignment() { TaskID = taskID, UserID = userID, Status = Status.New.ToString() };
                db.TaskAssignments.Add(taskAssignment);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}