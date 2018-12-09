using System.Configuration;
using System.Data.SqlClient;
using UWAdventure.Entities.Persistence;
using Dapper;
using UWHousing.Entities.DTO;
using UWHousing.Entities.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;
using UWAHousing.Enum;

namespace UWHousing.Data
{
    /// <summary>
    /// Data access object for students 
    /// </summary>
    public class StudentDAO
    {

        /// <summary>
        /// Creates a new student
        /// </summary>
        public void CreateStudent(NewStudentDTO newstudentDTO)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UWHousing"].ConnectionString)) //placeholder
            {
                connection.Open();
                string sql = @"Insert INTO Student (student.StudentID AS StudentID, 
                               student.Firstname AS Firstname,
                               student.Lastname AS Lastname, 
                               student.Buildingname AS Buildingname,
                               srudent.Roomnumber AS Roomnumber)
                               
                               Values (StudentID, Firstname, Lastname, Buildingname, Roomnumber)"
                    
                connection.Execute(sql, new { newstudentDTO });
            }
        public void GetStudent(long StudentID)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UWHousing"].ConnectionString)) //placeholder
            {
                connection.Open();
                string sql = @"SELECT student.Firstname AS Firstname, student.Lastname AS Lastname
                               FROM student
                               WHERE StudentID = StudentID;";                               
                    
                connection.Execute(sql, new { newstudentDTO });
            }
           
        }
  
