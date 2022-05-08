import React,{Component} from 'react'
import Navigation from '../Navigation'
import MovieList from '../cml/MovieList'


//<script src='/Security.js'></script>

export default function Movies() {

  return(
    <>
    <Navigation/>
      <div className="container">
        Movies
      <MovieList/>

    </div>
    </>
  )
} 

