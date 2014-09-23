using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Text;
using WindowsPhoneNotesWebApi.Models;

namespace WindowsPhoneNotesWebApi.Controllers
{
    public class GetMemberController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get(string login, string password)
        {
            Entities entities = new Entities();
            Member member = entities.GetMember(login, password);

            //Convert the database member entity into a more "MemberData" more friendly for JSON


            

            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            if(member != null)
            {
                MemberData md = new MemberData() {
                    Id = member.Id.ToString(),
                    Email = login,
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    Password = password
                };

                var test = JsonConvert.SerializeObject(md);

                resp.Content = new StringContent(JsonConvert.SerializeObject(md), Encoding.UTF8, "text/plain");
            }
            return resp;
        }
    }
}
