using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WindowsPhoneNotes.Classes.DataModels;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WindowsPhoneNotes.Classes
{
    public static class ServiceCalls
    {
        public static UserContext Login(string username, string password)
        {
            //http://localhost:65169/api/login?login=test&password=test
            string url = @"http://localhost:65169/api/login?" + "login=" + username + "&password=" + password;

            try
            {
                // HTTP web request
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";

                var response = httpWebRequest.GetResponseAsync().Result;
                var text = "";
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    text = sr.ReadToEnd();
                }

                if (text == "True")
                {
                    //User is succesfully authenticated. Now get the actual user info.

                    url = @"http://localhost:65169/api/getmember?" + "login=" + username + "&password=" + password;

                    // HTTP web request
                    httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.Method = "GET";

                    response = httpWebRequest.GetResponseAsync().Result;
                    text = "";
                    using (var sr = new StreamReader(response.GetResponseStream()))
                    {
                        text = sr.ReadToEnd();
                    }
                    Member member = (Member)JsonConvert.DeserializeObject(text, typeof(Member));

                    return new UserContext()
                    {
                        Authenticated = true,
                        UserName = username,
                        Password = password,
                        FirstName = member.FirstName,
                        LastName = member.LastName
                    };
                }

            }
            catch (Exception ex)
            {
                return new UserContext()
                {
                    Authenticated = false
                };
            }

            return new UserContext()
            {
                Authenticated = false
            };
        }

        public static List<Note> GetNotes(string username, string password)
        {
            //http://localhost:65169/api/login?login=test&password=test
            string url = @"http://localhost:65169/api/getnotes?" + "login=" + username + "&password=" + password;

            try
            {
                // HTTP web request
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";

                var response = httpWebRequest.GetResponseAsync().Result;
                var text = "";
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    text = sr.ReadToEnd();
                }

                List<Note> notes = (List<Note>)JsonConvert.DeserializeObject(text, typeof(List<Note>));

                return notes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool CreateNote(string username, string password, string title)
        {
            //http://localhost:65169/api/login?login=test&password=test
            string url = @"http://localhost:65169/api/createnote?" + "login=" + username + "&password=" + password + "&title=" + title;

            try
            {
                // HTTP web request
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";

                var response = httpWebRequest.GetResponseAsync().Result;

                var text = "";
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    text = sr.ReadToEnd();
                }

                if(text == "True")
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool UpdateNote(string username, string password, string title, string content)
        {
            //http://localhost:65169/api/login?login=test&password=test
            string url = @"http://localhost:65169/api/updatenote?" + "login=" + username + "&password=" + password + "&title=" + title + "&content=" + content;

            try
            {
                // HTTP web request
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";

                var response = httpWebRequest.GetResponseAsync().Result;

                var text = "";
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    text = sr.ReadToEnd();
                }

                if (text == "True")
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool DeleteNote(string username, string password, string title)
        {
            //http://localhost:65169/api/login?login=test&password=test
            string url = @"http://localhost:65169/api/deletenote?" + "login=" + username + "&password=" + password + "&title=" + title;

            try
            {
                // HTTP web request
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";

                var response = httpWebRequest.GetResponseAsync().Result;

                var text = "";
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    text = sr.ReadToEnd();
                }

                if (text == "True")
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool TestPost()
        {
            //http://localhost:65169/api/login?login=test&password=test
            string url = @"http://localhost:65169/api/testpost";

            try
            {
                HttpClient httpClient = new HttpClient();

                var message = new
                {
                    Username = "test",
                    Password = "1234"
                };
                var json_object = JsonConvert.SerializeObject(message);

                HttpContent content = new StringContent(json_object, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = httpClient.PostAsync(url, content).Result;
                string statusCode = response.StatusCode.ToString();

                PostResponse postResponse = (PostResponse)JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result, typeof(PostResponse));

                var msg = postResponse.Message;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
