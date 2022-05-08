import React,{Component} from 'react'
import  Navigation  from '../Navigation'
import SeriesList from '../cml/SeriesList'


//<script src='/Core/Security.js'></script>

export default function TVShows() {
    return(
        <>
        <Navigation/>
          <div className="container">
              Series
          <SeriesList/>
    
        </div>
        </>
      )
} 
