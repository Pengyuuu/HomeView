const requests = {
    fetchMoviePopular: `https://api.themoviedb.org/3/discover/movie?sort_by=popularity.desc&api_key=${process.env.REACT_APP_TMDB_API_KEY}`,
    fetchSeriesPopular: `https://api.themoviedb.org/3/discover/tv?sort_by=popularity.desc&api_key=${process.env.REACT_APP_TMDB_API_KEY}`,
}

export default requests;