import React from 'react'
import '../../css/test.css'
import Navigation from '../Navigation'
import RatingReview from './RatingReview'
import { Button, Card } from 'react-bootstrap'
import { render } from 'react-dom'



// Page for when a user clicks on a Title
// props = api data
export default function Title() {

    return (
        <>
            <Navigation>
            </Navigation>
            <div>

                <div className='background-Homeview'></div>
                <h1 style={{ color: "white" }}>title</h1>
                <p style={{ color: "white" }} > poster</p>
                <p style={{ color: "white" }}>description</p>
                <p style={{ color: "white" }}>Where to Watch:</p>
                <Button style={{ color: "white" }} onClick={createReview}>Click here to write a review</Button>

                </div>
        </>
    )


    /**
    return (
        <>
            <div>
                <div className='background-Homeview'></div>

                    <h1>{props.title}</h1>
                    <img src={props.poster_path}></img>
                    <p>{props.description}</p>
                    <p>Where to Watch:</p>
                <RatingReview> Rating review section for specific title </RatingReview>   

            </div>
        </>
    )**/
    function createReview() {
        return( < RatingReview > Rating review section for specific title </RatingReview >)

    }
}





