using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MvcApp.Models
{
    [DataContract]
    public class QuestionDto
    {
        [Required]
        [JsonProperty(PropertyName = "question")]
        [DataMember(IsRequired = true)]
        public string Question { get; set; }

        [Required]
        [JsonProperty(PropertyName = "markingCriteria")]
        [DataMember(IsRequired = true)]
        public string MarkingCriteria { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        [Range(0, 999)]
        [JsonProperty(PropertyName = "points")]
        public int Points { get; set; }
    }
}