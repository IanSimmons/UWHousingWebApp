using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Entities.ViewModels
{
    /// <summary>
    /// View model for payments
    /// </summary>
    public class PaymentViewModel
    {
        public long StudentID { get; set; } //probably dont need this
        public int PaymentAmount { get; set; }
        public DateTime Paymentdate { get; set; }

        //public override string ToString()
        //{
        //    if (StudentID == 0 )
        //        return base.ToString();
        //    else
        //        return StudentID;

        //}
    }
}
