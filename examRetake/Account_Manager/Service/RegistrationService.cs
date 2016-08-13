using examRetake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace examRetake.Account_Manager.Service
{
    public class RegistrationService
    {
        private examRetakeContext db;
        public RegistrationService()
        {
            db = new examRetakeContext();
        }

        public void AddRegistration(Users user)
        {
            db.Users.Add(new Users() { FirstName = user.FirstName, LastName = user.LastName, Username = user.Username, Password = user.Password, Role = user.Role != null ? user.Role : "user" });
            db.SaveChanges();
        }
    }
}