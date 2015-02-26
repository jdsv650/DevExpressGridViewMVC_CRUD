using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXWebApplication2.Models
{
    public class NoteViewModel
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }

    }
}
