using System.Configuration;
using System.Data.SqlClient;
using Housing.Entities.Persistence;
using Dapper;
using Housing.Entities.DTO;
using Housing.Entities.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Housing.Data
{
    /// <summary>
    /// Data access object for students 
    /// </summary>
    public class StudentDAO
    {

        /// <summary>
        /// Creates a new student
        /// </summary>
        public void CreateStudent(StudentDTO newstudentDTO)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Housing"].ConnectionString))
            {
                connection.Open();
                string sql = @"Insert INTO Student (StudentID, 
                               Firstname,
                               Lastname, 
                               Buildingname,
                               Roomnumber,
                               Studentaddress)
                               
                               Values (@StudentID, @Firstname, @Lastname, @Buildingname, @Roomnumber, @Address)";


                connection.Execute(sql, newstudentDTO);
            }

        }
        public IList<StudentViewModel> GetStudent(long StudentID)
        {
            IList<StudentViewModel> student;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Housing"].ConnectionString))
            {
                connection.Open();
                string sql = @"SELECT Firstname, Lastname, Studentaddress, Buildingname
                        FROM Student
                        WHERE StudentID = @StudentID";
                student = connection.Query<StudentViewModel>(sql).AsList();
                return student;
             }

        }

        public void UpdateStudent(StudentDTO updatestudentDTO)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Housing"].ConnectionString)) 
            {
                connection.Open();
                string sql = @"SET Studentaddress = @Studentaddress,
                             Buildingname= @Buildingname
                             WHERE StudentID = @StudentID";


                connection.Execute(sql, updatestudentDTO);
            }
        }

    }
}
