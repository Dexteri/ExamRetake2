using examRetake.Account_Manager.Security;
using examRetake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace examRetake.Account_Manager.Service
{
    public class UserManagingService
    {


        private examRetakeContext db;
        public UserManagingService()
        {
            db = new examRetakeContext();
        }
        public List<Users> GetUserList()
        {
            var nowUser = GetUserID();
            var users = db.Users.Where(x => x.UserID != nowUser).OrderBy(x => x.Role).Select(x => x).ToList();
            return users;
        }

        public int GetUserID()
        {
            var user = db.Users.Where(x => x.Username.Equals(SessionPersister.Username)).Select(x => x).First();
            return user.UserID;
        }
        public void Delete(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
        }
        public List<Users> GetStudentList()
        {
            var nowUser = GetUserID();
            var users = db.Users.Where(x => x.UserID != nowUser && !x.Role.Equals("admin")).OrderBy(x => x.Role).Select(x => x).ToList();
            return users;
        }
    }
}