using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MvcApp.Models
{
    [DataContract]
    public class AnswersDto
    {
        [DataMember]
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        [JsonProperty(PropertyName = "testId")]
        public Guid TestId { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        [JsonProperty(PropertyName = "answers")]
        public IEnumerable<AnswerDto> Answers { get; set; }
    }
}
