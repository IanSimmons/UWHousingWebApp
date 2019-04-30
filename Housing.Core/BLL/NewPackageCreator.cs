
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Housing.Data;
using Housing.Entities.DTO;
using Housing.Entities.Persistence;
using UWHousing.Entities.DTO;

namespace Housing.BLL
{
    /// <summary>
    /// Business object responsible for creating new packages in the system
    /// </summary>
    public class NewPackageCreator
    {
        private readonly PackageDAO _packageDAO;


        public NewPackageCreator()
        {
            _packageDAO = new PackageDAO();

        }

        /// <summary>
        /// Creates a new package
        /// </summary>
        public void CreatePackage(NewPackageDTO newPackageDTO)
        {
            // create the studentDTO for persistence and populate its properties
            PackageDTO packageDTO = new PackageDTO()
            {
                TrackingNum = newPackageDTO.Trackingnum,
                Firstname = newPackageDTO.Firstname,
                Lastname = newPackageDTO.Lastname,
            };

            _packageDAO.CreatePackage(packageDTO);

        }
    }
}