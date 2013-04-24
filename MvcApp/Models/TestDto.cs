using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MvcApp.Models
{
    [DataContract]
    public class TestDto
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "name")]
        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "questions")]
        [DataMember(IsRequired = true)]
        public IEnumerable<QuestionDto> Questions { get; set; }
    }
}