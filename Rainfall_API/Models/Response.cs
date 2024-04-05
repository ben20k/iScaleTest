

using System.Text.Json.Serialization;

namespace Rainfall_API.Models
{
    public class Response
    {
        [JsonIgnore]
        public int StatusCode { get; set; }
    }
}
