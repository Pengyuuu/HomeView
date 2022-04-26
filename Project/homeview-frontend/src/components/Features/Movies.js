import React,{Component} from 'react'
import Navigation from '../Navigation'

//<script src='/Security.js'></script>

export class Movies extends Component{
  render() {
    return(
        <div className="container">
        <h3 className="mt-5 d-flex justify-content-left">
        This is where the Movies will be.
        </h3>
        <Navigation/>
  
     </div>
    )
  } 
}
