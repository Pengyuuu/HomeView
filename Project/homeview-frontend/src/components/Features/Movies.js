import React, { Component } from 'react'
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
      <div className="container">
        Movies
        <MovieList />

      </div>
    </>
  )
}

