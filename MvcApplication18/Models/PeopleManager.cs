using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplication18.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class PeopleManager
    {
        private string _connectionString;

        public PeopleManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Person> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM People";
                List<Person> people = new List<Person>();
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Person person = new Person();
                    person.Id = (int)reader["Id"];
                    person.FirstName = (string)reader["FirstName"];
                    person.LastName = (string)reader["LastName"];
                    person.Age = (int)reader["Age"];
                    people.Add(person);
                }

                return people;
            }
        }

        public void Add(Person person)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO People (FirstName, LastName, Age) VALUES " +
                                  "(@firstName, @lastName, @age)";
                cmd.Parameters.AddWithValue("@firstName", person.FirstName);
                cmd.Parameters.AddWithValue("@lastName", person.LastName);
                cmd.Parameters.AddWithValue("@age", person.Age);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int personId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM People WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", personId);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}