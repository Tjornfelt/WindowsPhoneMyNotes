using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WindowsPhoneNotesWebApi.Models
{
    public class NotesData
    {
        public int NoteId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}