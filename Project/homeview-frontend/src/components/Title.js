import React from 'react'
import '../css/test.css'
import Navigation from './Navigation'
import RatingReview from './RatingReview'


// Page for when a user clicks on a Title
// props = api data
export default function Title() {
    const createRev = createReview()

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
                <RatingReview> Rating review section for specific title </RatingReview>
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
        return false
    }
}





