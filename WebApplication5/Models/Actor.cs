using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApplication5.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}