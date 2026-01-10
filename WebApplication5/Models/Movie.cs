using System;
using System.Text.Json.Serialization;

namespace WebApplication5.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ActorId { get; set; }
        public int FilmTypeId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Actor? Actor { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual FilmType? FilmType { get; set; }
    }
}