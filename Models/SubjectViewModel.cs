using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleResponsability.Models
{
    public class SubjectViewModel
    {
        public long subject_id { get; set; }
	    public string name { get; set; }
	    public string description { get; set; }
        public int isActive { get; set; }
    }
}
