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
    /// Business class for handling viewing of building view models
    /// </summary>
    public class RoomViewer
    {
        private readonly RoomDAO _room;
        

        public RoomViewer()
        {
            _room = new RoomDAO();
        }

        /// <summary>
        /// Returns view models of all rooms in a specific building
        /// </summary>
        public IList<RoomViewModel> GetOpenRoomsByBuilding(string Buildingname)
        {
            return _room.GetAllOpenRoomsByBuilding(Buildingname);
        }


    }
}
