using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Housing.Data;
using Housing.Entities.DTO;
using Housing.Entities.Persistence;
namespace Housing.BLL
{
    /// <summary>
    /// Business object responsible for creating new students in the system
    /// </summary>
    public class NewStudentCreator
    {
        private readonly StudentDAO _studentDAO;


        public NewStudentCreator()
        {
            _studentDAO = new StudentDAO();

        }

        /// <summary>
        /// Creates a new student
        /// </summary>
        public void CreateStudent(NewStudentDTO newStudentDTO)
        {
            // create the studentDTO for persistence and populate its properties
            StudentDTO studentDTO = new StudentDTO()
            {
                StudentID = newStudentDTO.StudentID,
                Firstname = newStudentDTO.Firstname,
                Lastname = newStudentDTO.Lastname,
                Buildingname = newStudentDTO.Buildingname,
                Roomnumber = newStudentDTO.Roomnumber,
            };

            _studentDAO.CreateStudent(studentDTO);
           
        }
    }
}
