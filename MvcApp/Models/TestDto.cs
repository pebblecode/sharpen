using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MvcApp.Models
{
    public class TestDto
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "questions")]
        public IEnumerable<QuestionDto> Questions { get; set; }
    }
}