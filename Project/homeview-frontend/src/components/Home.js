import React from 'react'
import Navigation from './Navigation'
import FirstTimeUser from './FirstTimeUser'
import MovieList from './cml/MovieList'

export default function Home() {

  //const userFirstTime = {}
    return (
      
      <div className='container'>
        <Navigation/>
        {MovieList()}
      </div>
  )
}
