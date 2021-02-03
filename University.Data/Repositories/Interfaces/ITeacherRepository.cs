using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Data.Models;

namespace University.Data.Interfaces
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetAll();
        Teacher Create(Teacher model);
    }
}
