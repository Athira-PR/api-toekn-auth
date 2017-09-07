using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using token_auth_example.Models;

namespace token_auth_example
{
    interface Iservice
    {
      
    userinfo_table GenerateToken(string name, string pwd);

        userinfo_table ValidateToken(string tokenvalue);
        
        
    }
}
