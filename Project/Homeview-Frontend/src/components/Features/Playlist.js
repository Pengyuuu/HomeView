import React,{Component} from 'react'
import {Form, Button, Card} from 'react-bootstrap'
import Navigation from '../Navigation'


//<script src='/Core/Security.js'></script>

export class Playlist extends Component{
  render() {
    return(
        <div>
            <div className='background-Homeview'></div>
            <Navigation/>
            <div className='card-center'></div>
                <Card>
                    <Card.Body>
                    <h2 className="text-left" style={{color: 'black'}}>Title</h2>
                    </Card.Body>
                </Card>
        </div>
    )
  } 
}
