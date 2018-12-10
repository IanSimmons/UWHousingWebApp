using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWHousing.Data;
using UWHousing.Entities.Persistence;
using UWHousing.Entities.ViewModels;

namespace UWHousing.BLL
{

    /// <summary>
    /// business class for student payment summary queries
    /// </summary>
    public class PaymentHistoryViewer
    {

        private readonly PaymentDAO _paymentDAO;

        //public void StudentPaymentViewer()
        //{
        //    _paymentDAO = new PaymentDAO();
        //}

        ///Retrieves payment summary for student

        public IList<PaymentHistoryViewModel> GetPaymentHistory(long StudentID) ///this seems pretty wrong
        {
            return _paymentDAO.GetPaymentHistory(StudentID);
        }
    }
}

