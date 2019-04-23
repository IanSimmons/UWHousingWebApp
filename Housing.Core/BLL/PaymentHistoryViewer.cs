using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Housing.Data;
using Housing.Entities.Persistence;
using Housing.Entities.ViewModels;

namespace Housing.BLL
{

    /// <summary>
    /// business class for student payment summary queries
    /// </summary>
    public class PaymentHistoryViewer
    {

        private readonly PaymentDAO _paymentDAO;

        public PaymentHistoryViewer()
        {
            _paymentDAO = new PaymentDAO();
        }

        ///Retrieves payment summary for student

        public IList<PaymentViewModel> GetPaymentHistory(long StudentID) ///this seems pretty wrong
        {
            return _paymentDAO.GetPaymentHistory(StudentID);
        }
    }
}

