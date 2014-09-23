using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneNotes.Classes
{
    public class NoteNavigationContext : NavigationContext
    {
        public string NoteHeader { get; set; }
        public string NoteBody { get; set; }
    }
}
