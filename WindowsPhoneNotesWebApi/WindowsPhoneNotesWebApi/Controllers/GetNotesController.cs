using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WindowsPhoneNotesWebApi.Models;

namespace WindowsPhoneNotesWebApi.Controllers
{
    public class GetNotesController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get(string login, string password)
        {
            Entities entities = new Entities();
            List<Note> notes = entities.GetNotes(login, password);

            //Convert the notes entity into a more "NotesData" more friendly for JSON

            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            if (notes != null)
            {
                List<NotesData> md = new List<NotesData>();

                foreach (var item in notes)
                {
		            NotesData nd = new NotesData(){
                        NoteId = item.Id,
                        Name = item.Title,
                        Content = item.Text
                    };

                    md.Add(nd);
                }

                resp.Content = new StringContent(JsonConvert.SerializeObject(md), Encoding.UTF8, "text/plain");
            }
            return resp;
        }
    }
}
