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
    /// Data access object for packages 
    /// </summary>
    public class PackageDAO
    {

        /// <summary>
        /// Creates a new package
        /// </summary>
        public void CreatePackage(PackageDTO newpackageDTO)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Housingousing"].ConnectionString))
            {
                connection.Open();
                string sql = @"Insert INTO Package (TrackingID, Firstname, Lastname, Logtime)
                               
                               Values (@Trackingnum, @Firstname , @Lastname, @Logtime)";


                connection.Execute(sql, newpackageDTO);
            }

        }
        public IList<PackageViewModel> GetPackages(string Firstname, string Lastname)
        {
            IList<PackageViewModel> package;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Housing"].ConnectionString))
            {
                connection.Open();
                string sql = @"SELECT *
                        FROM Package
                        Where Firstname = @Firstname and Lastname = @Lastname";
                package = connection.Query<PackageViewModel>(sql).AsList();
                return package;
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

        public void UpdatePackage(PackageDTO updatepackageDTO)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Housingousing"].ConnectionString)) 
            {
                connection.Open();
                string sql = @"UPDATE Package,
                             SET Releasetime = Releasetime
                             WHERE Firstname = @Firstname and Lastname = @Lastname and Releasetime is null";


                connection.Execute(sql, updatepackageDTO);
            }
        }

    }
}
