
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
    public class PackageReleaser
    {
        private readonly PackageDAO _packageDAO;


        public PackageReleaser()
        {
            _packageDAO = new PackageDAO();

        }

        /// <summary>
        /// Releases a package
        /// </summary>
        public void ReleasePackage(NewPackageDTO newPackageDTO)
        {
            // create the studentDTO for persistence and populate its properties
            PackageDTO packageDTO = new PackageDTO()
            {
                TrackingID = newPackageDTO.TrackingID,
                Releasetime = newPackageDTO.Releasetime               
            };

            _packageDAO.ReleasePackage(packageDTO);

        }
    }
}