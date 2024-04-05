using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace Rainfall_API.Models
{
    /// <summary>
    /// Details of invalid request property
    /// </summary>
    [DataContract]
    public partial class ErrorDetail
    {
        /// <summary>
        /// Gets or Sets PropertyName
        /// </summary>

        [DataMember(Name = "propertyName")]
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or Sets Message
        /// </summary>

        [DataMember(Name = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ErrorDetail {\n");
            sb.Append("  PropertyName: ").Append(PropertyName).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
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
