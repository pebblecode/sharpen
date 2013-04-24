using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MvcApp.Models
{
    public class QuestionDto
    {
        [Required]
        [JsonProperty(PropertyName = "question")]
        public string Question { get; set; }

        [Required]
        [JsonProperty(PropertyName = "markingCriteria")]
        public string MarkingCriteria { get; set; }

        [Required]
        [Range(0, 999)]
        public int Points { get; set; }
    }
}