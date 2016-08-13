using examRetake.Account_Manager.Security;
using examRetake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace examRetake.Account_Manager.Service
{
    public class AccountService
    {
        examRetakeContext db;
        public AccountService()
        {
            db = new examRetakeContext();
        }
        public bool AccessAccount()
        {
            string role = null;
            if (SessionPersister.Username != null)
                role = db.Users.Where(x => x.Username.Equals(SessionPersister.Username)).Select(x => x).FirstOrDefault().Role;

            return role != null ? (role.Equals("admin") ? true : false) : false;

        }
        public bool isLog()
        {
            return SessionPersister.Username != null ? false : true;
        }
    }
}