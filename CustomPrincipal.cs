using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using CustomAuthorization.Models;

namespace CustomAuthorization.Security
{
    public class CustomPrincipal:IPrincipal
    {
        private Account Account;
        //private AccountModel am = new AccountModel();

        public CustomPrincipal(Account account)
        {
            this.Account = account;
            this.Identity = new GenericIdentity(account.UserName);
        }
        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.Account.UserRoles.Contains(r));
        }
    }
}