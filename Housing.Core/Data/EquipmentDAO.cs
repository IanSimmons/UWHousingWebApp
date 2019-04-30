using System.Configuration;
using System.Data.SqlClient;
using Housing.Entities.Persistence;
using Dapper;
using Housing.Entities.DTO;
using Housing.Entities.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;
using UWHousing.Entities.DTO;

namespace Housing.Data
{
    /// <summary>
    /// Data access object for equipments 
    /// </summary>
    public class EquipmentDAO
    {
        public IList<EquipmentViewModel> GetEquipment(string Buildingname)
        {
            IList<EquipmentViewModel> equipment;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Housing"].ConnectionString))
            {
                connection.Open();
                string sql = @"SELECT *
                        FROM Checkout
                        Where Buildingname = @Buildingname and Status = 'In'";
                equipment = connection.Query<EquipmentViewModel>(sql).AsList();
                return equipment;
            }

        }

        /// <summary>
        /// Check Out Equipment
        /// </summary>
        public void CheckOut(NewCheckoutDTO newcheckoutDTO)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Housingousing"].ConnectionString))
            {
                connection.Open();
                string sql = @"Set StudentID = @StudentID, Status = 'Out'
                               Where LoanID = @LoanID";


                connection.Execute(sql, newcheckoutDTO);
            }

        }

        /// <summary>
        /// Check In Equipment
        /// </summary>
        public void CheckIn(NewCheckoutDTO newcheckoutDTO)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Housingousing"].ConnectionString))
            {
                connection.Open();
                string sql = @"Set StudentID = 0, Status = 'In'
                               Where LoanID = @LoanID";


                connection.Execute(sql, newcheckoutDTO);
            }

        }


        public IList<EquipmentViewModel> GetEquipmentByStudent(long EquipmentID)
        {
            IList<EquipmentViewModel> equipment;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Housing"].ConnectionString))
            {
                connection.Open();
                string sql = @"SELECT *
                        FROM Checkout
                        Where StudentId = @StudentID";
                equipment = connection.Query<EquipmentViewModel>(sql).AsList();
                return equipment;
            }

        }

    }
}
