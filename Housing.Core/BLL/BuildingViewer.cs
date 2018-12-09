using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWHousing.Data;
using UWHousing.Entities.ViewModels;

namespace UWHousing.BLL
{
    /// <summary>
    /// Business class for handling viewing of building view models
    /// </summary>
    public class BuildingViewer
    {
        private readonly BuildingDAO _buildingDAO;

        public BuildingViewer()
        {
            _buildingDAO = new BuildingDAO();
        }

        /// <summary>
        /// Returns view models of all buildings
        /// </summary>
        public string GetAllBuildingname()
        {
            return _buildingDAO.GetBuildingname();
        }


    }
}
