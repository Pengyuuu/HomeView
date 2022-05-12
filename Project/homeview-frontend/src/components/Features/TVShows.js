import React,{Component} from 'react'
import  Navigation  from '../Navigation'
import SeriesList from '../cml/SeriesList'
import LogAccess from '../Core/LogAccess'


//<script src='/Core/Security.js'></script>

export default function TVShows() {
  const TV_VIEW_ID = 4;
  LogAccess(TV_VIEW_ID);
  return (
    <>
      <Navigation />
      <div className="series-page">
        Series
        </div>
        <SeriesList />
     
    </>
  )
} 
