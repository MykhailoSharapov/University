using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Data.Models;

namespace University.Data.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student Create(Student model);
    }
}
