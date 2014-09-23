using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneNotes.Classes
{
    public class NavigationContext
    {
        public UserContext UserContext { get; set; }
        public Type NavigatedFrom { get; set; }
    }
}
