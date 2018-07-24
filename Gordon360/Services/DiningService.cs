﻿using System;
using System.Collections.Generic;
using System.Linq;
using Gordon360.Models.ViewModels;
using Gordon360.Repositories;
using Gordon360.Services.ComplexQueries;
using System.Data.SqlClient;
using System.Data;
using Gordon360.Exceptions.CustomExceptions;
using Gordon360.AuthorizationFilters;
using Gordon360.Static.Names;
using Gordon360.Static.Data;
using Gordon360.Static.Methods;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Security.Cryptography;

/// <summary>
/// We use this service to pull meal data from blackboard and parse it
/// </summary>
namespace Gordon360.Services
{
    /// <summary>
    /// Service that allows for meal control
    /// </summary>
    public class DiningService : IDiningService
    {
        // See UnitOfWork class
        private static string issuerID = "219";
        private static string applicationId = "000001";
        private static string secret = "test";

        private static string getTimestamp()
        {
            DateTime baseDate = new DateTime(1969, 12, 31, 20, 0, 0);
            TimeSpan diff = DateTime.Now - baseDate;
            Int64 millis = Convert.ToInt64(diff.TotalMilliseconds);
            return millis.ToString();
        }

        private static string getHash(string cardHolderID, string planID, string timestamp)
        {
            string hashstring = (secret + issuerID + cardHolderID + planID +
            applicationId + timestamp);

            SHA1 sha1 = SHA1.Create();
            var hash = sha1.ComputeHash(Encoding.ASCII.GetBytes(hashstring));
            var sb = new StringBuilder(hash.Length * 2);

            foreach (byte b in hash)
            {
                // can be "x2" if you want lowercase
                sb.Append(b.ToString("x2"));
            }
            Console.WriteLine(timestamp);
            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardHolderID"></param>
        /// <param name="planID"></param>
        /// <returns></returns>
        public string GetBalance(string cardHolderID, string planID)
        {
            ServicePointManager.Expect100Continue = false;

            WebRequest request = WebRequest.Create("https://bbapi.campuscardcenter.com/cs/api/mealplanDrCr");

            request.Method = "POST";

            string timestamp = getTimestamp();

            // Create POST data and convert it to a byte array.  
            string postData = "issuerId=" + issuerID + "&"
               + "cardholderId=" + cardHolderID + "&"
               + "planId=" + planID + "&"
               + "applicationId=" + applicationId + "&"
               + "valueCmd=bal" + "&" + "value=0" + "&"
               + "timestamp=" + timestamp + "&"
               + "hash=" + getHash(cardHolderID, planID, timestamp);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            // Get the response.  
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server.  
            dataStream = response.GetResponseStream();

            // Read the content. 
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            JObject json = JObject.Parse(responseFromServer);
            string balance = json["balance"].ToString();

            // Display the content.  
            Console.WriteLine(responseFromServer);
            Console.WriteLine("Balance: " + balance);

            // Clean up the streams.  
            reader.Close();
            dataStream.Close();
            response.Close();

            return balance;
        }

        /// <summary>
        /// Get information about the selected plan for the student user
        /// </summary>
        /// <param name="cardHolderID">Student's Gordon ID</param>
        /// <param name="sessionCode">Current Session Code</param>
        /// <returns></returns>
        public DiningViewModel GetDiningPlanInfo(string cardHolderID, string sessionCode)
        {
            var idParam = new SqlParameter("@STUDENT_ID", cardHolderID);
            var sessionParam = new SqlParameter("@SESS_CDE", sessionCode);
            var result = RawSqlQuery<DiningViewModel>.query("DINING_INFO_BY_STUDENT_ID @STUDENT_ID, @SESS_CDE", idParam, sessionParam).FirstOrDefault();
            if (result == null)
            {
                throw new ResourceNotFoundException() { ExceptionMessage = "The plan was not found." };
            }

            for (int i = 0; i < result.PlanIDs.Length; i++)
            {
                result.CurrentBalance[i] = GetBalance(cardHolderID, result.PlanIDs[i]);
            }

            return result;
        }
    }
}