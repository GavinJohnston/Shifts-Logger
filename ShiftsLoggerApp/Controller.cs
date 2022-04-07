using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using RestSharp;
using ConsoleTableExt;
using Newtonsoft.Json;
using System.Net.Http;

namespace ShiftsLoggerApp
{
    public class Controller
    {
        public static List<Shift> GetShiftsList() {

            string ListUrl = "https://localhost:7194/shiftslogger";

            var client = new RestClient(ListUrl);

            var request = new RestRequest();

            var response = client.GetAsync(request).Result.Content;

            JArray Json = JArray.Parse(response);

            var ShiftList = Json.ToObject<List<Shift>>();

            return ShiftList;
        }

        public static void SendShift(DateTime StartTime, DateTime EndTime, Decimal Minutes, Decimal Pay, string Location) {
            
          
        }
}