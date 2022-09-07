using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleResponsability.Models.Services
{
    public class StudentService
    {
        public List<StudentViewModel> List()
        {
            var oStudent = new List<StudentViewModel>();
            return oStudent;
        }
        public void Create(StudentViewModel student)
        {

        }
    }
}
