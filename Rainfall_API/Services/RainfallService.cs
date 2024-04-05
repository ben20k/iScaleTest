using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rainfall_API.Models;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;

namespace Rainfall_API.Services
{
    public class RainfallService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://environment.data.gov.uk/flood-monitoring/id/stations/";

        public RainfallService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<RainfallReadingResponse> GetRainfallData(string stationId, int limitCount)
        {
            try
            {
                // Make GET request to the API endpoint
                HttpResponseMessage response = await _httpClient.GetAsync($"{BaseUrl}/{stationId}/readings?_sorted&_limit={limitCount}");

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    List<RainfallReading> rainfallReadings = new List<RainfallReading>();
                    // Read the response content as a string
                    string responseBody = await response.Content.ReadAsStringAsync();

                    JObject jsonObj = JObject.Parse(responseBody);

                    // Accessing values
                    var items = jsonObj["items"];

                    foreach (var item in items)
                    {
                        var dateTime = item["dateTime"].ToString();
                        var value = item["value"].ToString();

                        DateTime rDateTime;
                        decimal rValue;

                        DateTime.TryParse(dateTime, out rDateTime);
                        Decimal.TryParse(value, out rValue);

                        RainfallReading rainfallReading = new RainfallReading();
                        rainfallReading.DateMeasured = rDateTime;
                        rainfallReading.AmountMeasured = rValue;

                        rainfallReadings.Add(rainfallReading);
                    }


                    var rainfallReadingResponse = new RainfallReadingResponse();
                    rainfallReadingResponse.Readings = rainfallReadings;

                    return rainfallReadingResponse;
                }
                else
                {
                    // If request was not successful, throw an exception or handle the error accordingly
                    response.EnsureSuccessStatusCode();
                    return null; // Return default value or handle error as per requirement
                }
            }
            catch (Exception ex)
            {
                // Handle exception appropriately, such as logging or throwing further
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
