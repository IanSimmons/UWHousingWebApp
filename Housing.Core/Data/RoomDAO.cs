using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Housing.Entities.ViewModels;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
namespace Housing.Data
{
    /// <summary>
    /// Data access object for rooms
    /// </summary>
    public class RoomDAO
    {
        /// <summary>
        /// Returns view models of all available rooms in a building
        /// </summary>
        /// <returns></returns>
        public IList<RoomViewModel> GetAllOpenRoomsByBuilding(string Buildingname)
        {
            IList<RoomViewModel> room;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Housingousing"].ConnectionString))
            {
                connection.Open();

                string sql = @"SELECT Roomnumber
                               FROM Room
                               WHERE Occupied LIKE 'No,*';";
                
                room = connection.Query<RoomViewModel>(sql, new { Buildingname })
                    .ToList();

            }

            return room;
        }
    }
}
