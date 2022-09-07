using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleResponsability.Models
{
    public partial class StudentViewModel
    {
        public long IdAlumno { get; set; }
        public long dni { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string Genre { get; set; }
        public string Email { get; set; }
        public bool? BanActivo { get; set; }
    }
}
