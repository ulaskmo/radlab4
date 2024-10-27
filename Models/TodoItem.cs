using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace radlab4._0.Models
{
    public enum Status
    {
        NotStarted,
        InProgress,
        Completed,
        Cancelled
    }

    public class TodoItem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Status Status { get; set; }
    }
}