import React from 'react'
import Navigation from '../Navigation'
import MovieList from '../cml/MovieList'
import LogAccess from '../Core/LogAccess'


//<script src='/Security.js'></script>

export default function Movies() {
  const MOVIE_VIEW_ID = 3;
  LogAccess(MOVIE_VIEW_ID);

  return (
    <>
      <Navigation />
      <div className="movies-page">
        Movies
        </div>
        <MovieList />
      
    </>
  )
}

