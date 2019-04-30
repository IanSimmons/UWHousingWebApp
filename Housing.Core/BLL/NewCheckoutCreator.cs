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
    /// Business object responsible for creating new equipments in the system
    /// </summary>
    public class NewCheckoutCreator
    {
        private readonly EquipmentDAO _equipmentDAO;


        public NewCheckoutCreator()
        {
            _equipmentDAO = new EquipmentDAO();

        }

        /// <summary>
        /// Creates a new equipment
        /// </summary>
        public void CheckOut(NewCheckoutDTO newCheckoutDTO)
        {
            // create the equipmentDTO for persistence and populate its properties
            CheckoutDTO checkoutDTO = new CheckoutDTO()
            {
                EquipmentID = newCheckoutDTO.EquipmentID,
                StudentID = newCheckoutDTO.StudentID              
            };

            _equipmentDAO.CheckOut(checkoutDTO);
           
        }
    }
}
