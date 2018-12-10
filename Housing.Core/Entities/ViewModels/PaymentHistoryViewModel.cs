using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWHousing.Entities.ViewModels
{

    /// <summary>
    /// View model for payments
    /// </summary>
    public class PaymentHistoryViewModel //iList of payments within
    {
        public PaymentHistoryViewModel()
        {
            payments = new List<PaymentViewModel>();
        }
        //join in data code to join student table with payment table, dapper multiplemapping
        public IList<PaymentViewModel> payments { get; set; }
        //public string Firstname { get; set; }
        //public string Lastname { get; set; }


    }
}
