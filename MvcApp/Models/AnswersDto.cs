using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MvcApp.Models
{
    public class AnswersDto
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "testId")]
        public Guid TestId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "answers")]
        public IEnumerable<AnswerDto> Answers { get; set; }
    }
}
