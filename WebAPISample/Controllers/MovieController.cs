using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPISample.Data;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private ApplicationContext _context;
        public MovieController(ApplicationContext context)
        {
            _context = context;
        }
        // GET api/movie
        [HttpGet]
        public IActionResult Get()
        {
            // Retrieve all movies from db logic

            var movies = _context.Movies;
            return Ok(movies);
        }

        // GET api/movie/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // Retrieve movie by id from db logic
            Movie movie = new Movie();
            // return Ok(movie);
            movie = _context.Movies.Find(id);
            return Ok(movie);
        }

        // POST api/movie
        [HttpPost]
        public IActionResult Post([FromBody]Movie value)
        {
            Movie movie = new Movie
            {
                Title = value.Title,
                Director = value.Director,
                Genre = value.Genre

            };
            _context.Movies.Add(movie);
            _context.SaveChanges();

            // Create movie in db logic
            return Ok(movie);   
        }

        // PUT api/movie
        [HttpPut]
        public IActionResult Put([FromBody] Movie movie)
        {
            // Update movie in db logic
            var movieInDb = _context.Movies.Where(a => a.MovieId == movie.MovieId).FirstOrDefault();
            movieInDb.Title = movie.Title;
            movieInDb.Director = movie.Director;
            movieInDb.Genre = movie.Genre;
            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/movie/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Where(b => b.MovieId == id).FirstOrDefault();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
           
            // Delete movie from db logic
            return Ok();
        }
    }
}