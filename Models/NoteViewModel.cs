using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleResponsability.Models
{
    public class NoteViewModel
    {
        public int note_id { get; set; }
        public int student_id { get; set; }
        public int subject_id { get; set; }
        public float note { get; set; }
    }
}
