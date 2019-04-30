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
    /// Data access object for packages 
    /// </summary>
    public class PackageDAO
    {

        /// <summary>
        /// Creates a new package
        /// </summary>
        public void CreatePackage(NewPackageDTO newpackageDTO)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Housing"].ConnectionString))
            {
                connection.Open();
                string sql = @"Insert INTO Package (TrackingID, Firstname, Lastname, Logtime, Buildingname )
                               
                               Values (@TrackingID, @Firstname , @Lastname, @Logtime, @Buildingname)";


                connection.Execute(sql, newpackageDTO);
            }

        }
        public IList<PackageViewModel> GetPackages(string Firstname, string Lastname)
        {
            IList<PackageViewModel> package;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Housing"].ConnectionString))
            {
                connection.Open();
                string sql = @"SELECT TrackingID as TrackingID
                        FROM Package
                        Where Firstname = @Firstname and Lastname = @Lastname";
                var param = new { Firstname, Lastname };
                return connection.Query<PackageViewModel>(sql, new { Firstname, Lastname }).AsList();
            }

        }

        public IList<PackageViewModel> GetPackagesByBuilding(string Buildingname)
        {
            IList<PackageViewModel> package;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Housing"].ConnectionString))
            {
                connection.Open();
                string sql = @"SELECT *
                        FROM Package
                        Where Buildingname = @Buildingname and Arrivedate > Convert(date, getdate()-7";
                package = connection.Query<PackageViewModel>(sql).AsList();
                return package;
             }

        }

        public void ReleasePackage(PackageDTO releasepackageDTO)
        {
            long TrackingID = releasepackageDTO.TrackingID;
            DateTime Releasetime = releasepackageDTO.Releasetime;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Housing"].ConnectionString)) 
            {
                connection.Open();
                string sql = @"UPDATE Package,
                             SET Releasetime = @Releasetime
                             WHERE TrackingID = @TrackingID";

                var param = new { Releasetime, TrackingID };

                connection.Execute(sql, new { Releasetime, TrackingID });
            }
        }

    }
}
