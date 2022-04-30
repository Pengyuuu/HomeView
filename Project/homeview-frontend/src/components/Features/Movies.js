import React,{Component} from 'react'
import Navigation from '../Navigation'
import MovieList from '../cml/MovieList'


//<script src='/Security.js'></script>

export class Movies extends Component {
  render() {
    return(
        <div className="container">

        <Navigation/>
        <MovieList/>
  
     </div>
    )
  } 
}
