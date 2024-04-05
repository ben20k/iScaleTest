using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace Rainfall_API.Models
{
    /// <summary>
    /// An error object returned for failed requests
    /// </summary>
    [DataContract]
    public partial class ErrorResponse: Response
    {
        /// <summary>
        /// Gets or Sets Message
        /// </summary>

        [DataMember(Name = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or Sets Detail
        /// </summary>

        [DataMember(Name = "detail")]
        public List<ErrorDetail> Detail { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ErrorResponse {\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Detail: ").Append(Detail).Append("\n");
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
