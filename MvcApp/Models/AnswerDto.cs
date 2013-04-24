using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MvcApp.Models
{
    [DataContract]
    public class AnswerDto
    {
        [Required]
        [DataMember(IsRequired = true)]
        [JsonProperty(PropertyName = "question")]
        public string Question { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        [JsonProperty(PropertyName = "answer")]
        public string Answer { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        [JsonProperty(PropertyName = "markingCriteria")]
        public string MarkingCriteria { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        [Range(0, 999)]
        [JsonProperty(PropertyName = "points")]
        public int Points { get; set; }
    }
}
