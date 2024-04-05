using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace Rainfall_API.Models
{
    /// <summary>
    /// Details of a rainfall reading
    /// </summary>
    [DataContract]
    public partial class RainfallReadingResponse
    {
        /// <summary>
        /// Gets or Sets Readings
        /// </summary>

        [DataMember(Name = "readings")]
        public List<RainfallReading> Readings { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RainfallReadingResponse {\n");
            sb.Append("  Readings: ").Append(Readings).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
