using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleResponsability.Models.Services
{
    public class NoteService
    {
        public NoteService()
        {

        }

        public List<NoteViewModel> List()
        {
            var oNote = new List<NoteViewModel>();
            return oNote;
        }
    }
}
