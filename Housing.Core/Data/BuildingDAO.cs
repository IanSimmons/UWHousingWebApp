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
        IList<BuildingViewModel> buildings;

        /// <summary>
        /// Returns list of buildings
        /// </summary>
        public IList<BuildingViewModel> GetBuildingname()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UWHousing"].ConnectionString))
            {
                connection.Open();
                string sql = @"SELECT Buildingname
                         from Building";

                buildings = connection.Query<BuildingViewModel>(sql).AsList();
                return buildings;
            }

        }
    }
}
