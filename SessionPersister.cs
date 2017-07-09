using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomAuthorization.Security
{
    public static class SessionPersister
    {
        static string userNameSessionVar = "Username";

        public static string UserName
        {
            get { 
                if(HttpContext.Current==null)
                {
                    return string.Empty;
                }
                var sessionVar = HttpContext.Current.Session[userNameSessionVar];
                if(sessionVar!=null)
                {
                    return sessionVar as string;
                }
                return null;

            
            }
            set
            {
                HttpContext.Current.Session[userNameSessionVar] = value;
            }
        
        }
    }
}