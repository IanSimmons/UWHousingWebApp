using System.Configuration;
using System.Data.SqlClient;
using UWHousing.Entities.Persistence;
using Dapper;
using UWHousing.Entities.DTO;
using UWHousing.Entities.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;

namespace UWHousing.Data
{
    /// <summary>
    /// Data access object for housing
    /// </summary>
    public class BuildingDAO
    {

        /// <summary>
        /// Returns list of buildings
        /// </summary>
        public string GetBuildingname()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UWHousing"].ConnectionString))
            {
                connection.Open();
                return @"SELECT Buildingname
                         FROM Building";
            }

        }
    }
}
