import React, { useState } from 'react'
import Navigation from '../../Navigation'
import RatingReview from './RatingReview'
import { Button, Card } from 'react-bootstrap'
import { render } from 'react-dom'

// props = api data
export default function Title() {
   
    // title should take in api data and user's review data

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

}





