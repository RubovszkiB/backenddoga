using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<FilmType> FilmTypes { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity => {
                entity.ToTable("actors");
                entity.HasKey(e => e.ActorId);
                entity.Property(e => e.ActorId).HasColumnName("actor_id");
                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<FilmType>(entity => {
                entity.ToTable("film_type");
                entity.HasKey(e => e.FilmTypeId);
                entity.Property(e => e.FilmTypeId).HasColumnName("film_type_id");
                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Movie>(entity => {
                entity.ToTable("movies");
                entity.HasKey(e => e.MovieId);
                entity.Property(e => e.MovieId).HasColumnName("movie_id");
                entity.Property(e => e.Title).HasColumnName("title");
                entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
                entity.Property(e => e.ActorId).HasColumnName("actor_id");
                entity.Property(e => e.FilmTypeId).HasColumnName("film_type_id");

                entity.HasOne(d => d.Actor).WithMany(p => p.Movies)
                    .HasForeignKey(d => d.ActorId).OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.FilmType).WithMany(p => p.Movies)
                    .HasForeignKey(d => d.FilmTypeId);
            });
        }
    }
}