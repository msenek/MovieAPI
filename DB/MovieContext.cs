using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;
namespace MovieAPI.DB

{
    public class MovieContex : DbContext
    {

        public DbSet<Movie> Movies { get; set; }
        public MovieContex(DbContextOptions<MovieContex> options) : base(options)
        {  
        }
    }
}