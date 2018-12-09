using System.Configuration;
using System.Data.SqlClient;
using UWAdventure.Entities.Persistence;
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

        /// <summary>
        /// returns full order details for a single order
        /// </summary>
        public string GetRunPaymentHistory(int StudentID)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UWHousing"].ConnectionString)) //I don't think this is right but we need to connect somewhere
            {
                connection.Open();
                return @"SELECT payment.paymentdate AS PaymentDate,
                               payment.paymentenclose AS PaymentEnclosed
                               FROM payment
                               WHERE payment.StudentID = StudentID;";
                connection.Execute(sql, new {newpaymentDTO});
                
                //IList<PaymentHistoryViewModel> payments = QueryForGetRunPaymentHistory("payments.student_id=@student_id");//syntax will likely change
                //return payments.Count > 0 ? payments : null; //if this works it doesn't return everything we want/in the format we want it
        }
    }
