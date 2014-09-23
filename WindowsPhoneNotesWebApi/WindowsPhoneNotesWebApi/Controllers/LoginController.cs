using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace WindowsPhoneNotesWebApi.Controllers
{
    public class LoginController : ApiController
    {
        
        [HttpGet]
        public HttpResponseMessage Get(string login, string password)
        {
            Entities entities = new Entities();
            bool result = entities.Authenticate(login, password);

            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result.ToString(), Encoding.UTF8, "text/plain");

            return resp;
        }
    }
}
