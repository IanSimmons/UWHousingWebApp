using System.Configuration;
using System.Data.SqlClient;
using Housing.Entities.Persistence;
using Dapper;
using Housing.Entities.DTO;
using Housing.Entities.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Housing.Data
{
    /// <summary>
    /// Data access object for payment history 
    /// </summary>
    public class PaymentDAO
    {

        IList<PaymentHistoryViewModel> payments;

        /// <summary>
        /// returns full order details for a single order
        /// </summary>
        public IList<PaymentViewModel> GetPaymentHistory(long StudentID)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Housing"].ConnectionString)) //I don't think this is right but we need to connect somewhere
            {
                connection.Open();
                string sql = "SELECT Firstname, Lastname, Paymentenclosed As PaymentAmount, Paymentdate FROM student AS A INNER JOIN payment AS B On A.StudentID = B.StudentID " +
                                "Where A.StudentID = @StudentID";

                var param = new { StudentID };

                return connection.Query<PaymentViewModel>(sql, new { StudentID }).AsList();

                //connection.Execute(sql, new {newpaymentDTO});

                //IList<PaymentHistoryViewModel> payments = QueryForGetRunPaymentHistory("payments.student_id=@student_id");//syntax will likely change
                //return payments.Count > 0 ? payments : null; //if this works it doesn't return everything we want/in the format we want it

            }
        }

    }
}
