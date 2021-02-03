using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Data.Interfaces;
using University.Data.Models;

namespace University.Data.Repositories
{
    public class StudentDapperRepository : IStudentRepository
    {
        private const string CONNECTION_STRING = "Data Source=.;Initial Catalog=Zoo;Integrated Security=True";
        public Student Create(Student model)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                var queryString = $"INSERT INTO Students(Name,BreedId) OUTPUT INSERTED.id VALUES(\'{model.FirstName}\',{model.LastName})";
                var insertedId = connection.ExecuteScalar(queryString);
                var insertedIdInt = Convert.ToInt32(insertedId);
                model.Id = insertedIdInt;
                return model;
            }
        }

        public IEnumerable<Student> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                return connection.Query<Student>("SELECT * FROM Students");
            }
        }
    }
}
