using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using token_auth_example.Models;

namespace token_auth_example.Controllers
{
    public class LoginController : ApiController
    {
        service obj = new service();
        
       
        private HttpResponseMessage GetAuthToken(string username, string password)
        {
            var token = obj.GenerateToken(username, password);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
            response.Headers.Add("Token", token.authtoken);
            response.Headers.Add("TokenExpiry", DateTime.Now.AddHours(2).ToString());
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
            return response;
        }

        [Route("Authenticating")]
        [HttpGet]
        public HttpResponseMessage Authenticate(string username, string password)
        {
            return GetAuthToken(username, password);
        }

        [AuthorizationRequired]
        [Route("GetUserAgain")]
        public string GetUserDetails(string username)
        {
            return "Invalid";
        }


         
        
    }
      
}


