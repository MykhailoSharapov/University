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
    public class TeacherAdoNetRepository: ITeacherRepository
    {
        private const string CONNECTION_STRING = "Data Source=.;Initial Catalog=Zoo;Integrated Security=True";

        public Teacher Create(Teacher model)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                var queryString = "INSERT INTO Teachers(FristName,LastName,LessonId) OUTPUT INSERTED.id VALUES(@FirstName,@LastName,1)";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Name", model.FirstName);
                command.Parameters.AddWithValue("@BreedId", model.LastName);
                connection.Open();
                model.Id = Convert.ToInt32(command.ExecuteScalar()); 
                return model;
            }
        }

        public IEnumerable<Teacher> GetAll()
        {
            var result = new List<Teacher>();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                var queryString = "SELECT * FROM Teachers";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Teacher
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2)
                    });
                }
                reader.Close();
                return result;
            }
        }
    }
}
