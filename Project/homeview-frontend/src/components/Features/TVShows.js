import React,{Component} from 'react'
import {Navigation} from '../Navigation'

export class TVShows extends Component{
    render() {
        return (
            <div className="container">
                <h3 className="mt-5 d-flex justify-content-left">
                    This is where the TV Shows will be.
                </h3>
            <Navigation/>
            </div>
        )
    } 
}
