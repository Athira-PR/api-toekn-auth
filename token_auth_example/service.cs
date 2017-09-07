using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using token_auth_example.Models;

namespace token_auth_example
{
    public class service : Iservice
    {

        public userinfo_table GenerateToken(string name, string pwd)
        {
            string token = Guid.NewGuid().ToString();
            DateTime IssuedOn = DateTime.Now;
            DateTime ExpiredOn = DateTime.Now.AddSeconds(50000000);
            
            
            var TokenKey = new userinfo_table
            {
               
                usrname=name,
                authtoken = token,
                issued_on = IssuedOn,
                expired_on = ExpiredOn

            };
            userinfo_table usr = new userinfo_table();
            advancedEntities4 context = new advancedEntities4();
            usr = (from u in context.userinfo_table
                   where u.usrname == name & u.password == pwd
                   select u).FirstOrDefault();
            if(usr.usrname!=null)
            {
                usr.authtoken = TokenKey.authtoken;
                usr.issued_on = TokenKey.issued_on;
                usr.expired_on = TokenKey.expired_on;
                context.SaveChanges();

            }

            return TokenKey;


        }

        internal bool ValidateToken(string tokenValue)
        {
            throw new NotImplementedException();
        }
        userinfo_table Iservice. ValidateToken(string tokenvalue)
        {
            throw new NotImplementedException();
        }

      

       
    }
}




