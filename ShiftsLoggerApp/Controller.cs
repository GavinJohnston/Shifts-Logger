using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using RestSharp;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;

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

        public static async void SendShift(DateTime StartTime, DateTime EndTime, Decimal Minutes, Decimal Pay, string Location) {
            
          Shift NewShift = new Shift {
              Start = StartTime,
              End = EndTime,
              Pay = Pay,
              Minutes = Minutes,
              Location = Location 
          };

          var Json = JsonConvert.SerializeObject(NewShift);

          var data = new StringContent(Json, Encoding.UTF8, "application/json");

          var url = "https://localhost:7194/shiftslogger";

          using var client = new HttpClient();

          var response = await client.PostAsync(url, data);

          var result = await response.Content.ReadAsStringAsync();

          Console.WriteLine("Shift Logged. Press any Key to return to Main Menu");   
        }

        public static async void EditShift(int ShiftId, DateTime StartTime, DateTime EndTime, Decimal Minutes, Decimal Pay, string Location) {

            Shift UpdatedShift = new Shift {
                ShiftId = ShiftId,
                Start = StartTime,
                End = EndTime,
                Pay = Pay,
                Minutes = Minutes,
                Location = Location,
            };

            var json = JsonConvert.SerializeObject(UpdatedShift);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:7194/shiftslogger";

            using var client = new HttpClient();

            var response = await client.PutAsync($"{url}/{ShiftId}", data);

            var result = await response.Content.ReadAsStringAsync();

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}