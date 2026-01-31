using Microsoft.AspNetCore.Mvc;
using MovieAPI.DB;
using MovieAPI.Models;
using System;
using System.Collections.Generic;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContex _context;

        public MoviesController(MovieContex context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<MovieResponeDto>> GetMovies()
        {
            try
            {
                var response = new List<MovieResponeDto>();

                foreach (var movie in _context.Movies)
                {
                    response.Add(new MovieResponeDto
                    {
                        MovieId = movie.MovieId,
                        MovieName = movie.MovieName,
                        MovieReview = movie.MovieReview,
                        MovieDate = movie.MovieDate,
                        MovieAgeRange = movie.MovieAgeRange
                    });
                }

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al obtener las películas");
            }
        }


        [HttpGet("{id}")]
        public ActionResult<MovieResponeDto> GetMovieById(int id)
        {
            try
            {
                var movie = _context.Movies.Find(id);

                if (movie == null)
                {
                    return NotFound("Película no encontrada");
                }

                var response = new MovieResponeDto
                {
                    MovieId = movie.MovieId,
                    MovieName = movie.MovieName,
                    MovieReview = movie.MovieReview,
                    MovieDate = movie.MovieDate,
                    MovieAgeRange = movie.MovieAgeRange
                };

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al obtener la película");
            }
        }

        [HttpPost]
        public ActionResult CreateMovie(MovieRequestDto dto)
        {
            try
            {
                var movie = new Movie
                {
                    MovieName = dto.MovieName,
                    MovieReview = dto.MovieReview,
                    MovieDate = dto.MovieDate,
                    MovieAgeRange = dto.MovieAgeRange
                };

                _context.Movies.Add(movie);
                _context.SaveChanges();

                return Ok("Película creada correctamente");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al crear la película");
            }
        }


        [HttpPut("{id}")]
        public ActionResult UpdateMovie(int id, MovieRequestDto dto)
        {
            try
            {
                var movie = _context.Movies.Find(id);

                if (movie == null)
                {
                    return NotFound("Película no encontrada");
                }

                movie.MovieName = dto.MovieName;
                movie.MovieReview = dto.MovieReview;
                movie.MovieDate = dto.MovieDate;
                movie.MovieAgeRange = dto.MovieAgeRange;

                _context.SaveChanges();

                return Ok("Película actualizada correctamente");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al actualizar la película");
            }
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            try
            {
                var movie = _context.Movies.Find(id);

                if (movie == null)
                {
                    return NotFound("Película no encontrada");
                }

                _context.Movies.Remove(movie);
                _context.SaveChanges();

                return Ok("Película eliminada correctamente");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al eliminar la película");
            }
        }


        [HttpGet("adults")]
        public ActionResult<List<MovieResponeDto>> GetAdultsMovies()
        {
            try
            {
                var response = new List<MovieResponeDto>();

                foreach (var movie in _context.Movies)
                {
                    if (movie.MovieAgeRange >= 18)
                    {
                        response.Add(new MovieResponeDto
                        {
                            MovieId = movie.MovieId,
                            MovieName = movie.MovieName,
                            MovieReview = movie.MovieReview,
                            MovieDate = movie.MovieDate,
                            MovieAgeRange = movie.MovieAgeRange
                        });
                    }
                }

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al obtener películas para adultos");
            }
        }


        [HttpGet("minors")]
        public ActionResult<List<MovieResponeDto>> GetMinorsMovies()
        {
            try
            {
                var response = new List<MovieResponeDto>();

                foreach (var movie in _context.Movies)
                {
                    if (movie.MovieAgeRange < 18)
                    {
                        response.Add(new MovieResponeDto
                        {
                            MovieId = movie.MovieId,
                            MovieName = movie.MovieName,
                            MovieReview = movie.MovieReview,
                            MovieDate = movie.MovieDate,
                            MovieAgeRange = movie.MovieAgeRange
                        });
                    }
                }

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al obtener películas para menores");
            }
        }
    }
}
