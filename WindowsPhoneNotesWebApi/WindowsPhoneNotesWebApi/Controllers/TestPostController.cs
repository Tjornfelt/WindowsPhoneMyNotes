using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace WindowsPhoneNotesWebApi.Controllers
{
    public class TestPostController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(PostData data)
        {
            var test = "did something happen?";

            var resp = new HttpResponseMessage(HttpStatusCode.OK);

            var responseObj = new
            {
                Message = "You rock!"
            };

            var testres = JsonConvert.SerializeObject(responseObj);

            resp.Content = new StringContent(testres, Encoding.UTF8, "text/plain");
            
            return resp;
        }
    }

    public class PostData
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
