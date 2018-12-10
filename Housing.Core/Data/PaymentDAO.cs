using System.Configuration;
using System.Data.SqlClient;
using UWHousing.Entities.Persistence;
using Dapper;
using UWHousing.Entities.DTO;
using UWHousing.Entities.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;

namespace UWHousing.Data
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
        public IList<PaymentHistoryViewModel> GetPaymentHistory(long StudentID)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UWHousing"].ConnectionString)) //I don't think this is right but we need to connect somewhere
            {
                connection.Open();
                string sql = @"SELECT Paymentdate AS PaymentDate,
                               Paymentenclosed AS PaymentEnclosed
                               FROM Payment
                               WHERE Payment.StudentID = StudentID;";
                payments = connection.Query<PaymentHistoryViewModel>(sql).AsList();
                return payments;

                //connection.Execute(sql, new {newpaymentDTO});

                //IList<PaymentHistoryViewModel> payments = QueryForGetRunPaymentHistory("payments.student_id=@student_id");//syntax will likely change
                //return payments.Count > 0 ? payments : null; //if this works it doesn't return everything we want/in the format we want it

            }
        }

    }
}
