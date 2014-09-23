using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace WindowsPhoneNotesWebApi.Controllers
{
    public class UpdateNoteController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get(string login, string password, string title, string content)
        {
            Entities entities = new Entities();
            bool result = entities.UpdateNote(login, password, title, content);

            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result.ToString(), Encoding.UTF8, "text/plain");

            return resp;
        }
    }
}
