using examRetake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace examRetake.Account_Manager.Model
{
    public class AccountModel
    {
        private examRetakeContext db = new examRetakeContext();
        public Users find(string username)
        {
            var us = db.Users.Where(x => x.Username.Equals(username)).FirstOrDefault();
            return new Users() { Username = us.Username, Password = us.Password, Role = us.Role };
        }
        public Users login(string username, string password)
        {
            var us = db.Users.Where(x => x.Username.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
            if (us != null)
                return new Users() { Username = us.Username, Password = us.Password, Role = us.Role };
            return null;
        }
    }
}