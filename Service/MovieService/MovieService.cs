using System;
using System.Collections.Generic;
using Domain;
using Repository;

namespace Service
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;

        public MovieService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        

        public Movie GetSpecificMovie(Guid? id)
        {
            return _movieRepository.Get(id);
        }
        public IEnumerable<Movie> GetAllMovies()
        {
            return _movieRepository.GetAll();
        }
    }
}