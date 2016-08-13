using examRetake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace examRetake.Account_Manager.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private Users User;
        public CustomPrincipal(Users account)
        {
            this.User = account;
            this.Identity = new GenericIdentity(account.Username);
        }
        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.User.Role.Contains(r));
        }
    }
}