using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Housing.Data;
using Housing.Entities.ViewModels;

namespace Housing.BLL
{
    /// <summary>
    /// Business class for handling viewing of equipment view models
    /// </summary>
    public class EquipmentViewer
    {
        private readonly EquipmentDAO _equipmentDAO;

        public EquipmentViewer()
        {
            _equipmentDAO = new equipmentDAO();
        }

        /// <summary>
        /// Returns view models of all equipment by building
        /// </summary>
        public IList<EquipmentViewModel> GetAllequipmentname()
        {
            return _equipmentDAO.Getequipmentname();
        }


    }
}
