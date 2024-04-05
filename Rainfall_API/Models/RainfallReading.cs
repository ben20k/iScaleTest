using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Rainfall_API.Models
{
    /// <summary>
    /// Details of a rainfall reading
    /// </summary>
    [DataContract]
    public partial class RainfallReading
    {
        /// <summary>
        /// Gets or Sets DateMeasured
        /// </summary>

        [DataMember(Name = "dateMeasured")]
        public DateTime? DateMeasured { get; set; }

        /// <summary>
        /// Gets or Sets AmountMeasured
        /// </summary>

        [DataMember(Name = "amountMeasured")]
        public decimal? AmountMeasured { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RainfallReading {\n");
            sb.Append("  DateMeasured: ").Append(DateMeasured).Append("\n");
            sb.Append("  AmountMeasured: ").Append(AmountMeasured).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

    }
}
