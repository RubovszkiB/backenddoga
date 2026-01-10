using System.Collections.Generic;

namespace WebApplication5.Models
{
    public class FilmType
    {
        public int FilmTypeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}