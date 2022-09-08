using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SingleResponsability.Models
{
    public class NoteViewModel
    {
        [Key]
        public int note_id { get; set; }

        public int student_id { get; set; }
        public int subject_id { get; set; }
        public string? name { get; set; }
        public float note { get; set; }
    }
}
