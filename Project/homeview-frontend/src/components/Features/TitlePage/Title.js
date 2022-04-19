import React, { useState } from 'react'
import '../../../css/test.css'
import Navigation from '../../Navigation'
import RatingReview from './RatingReview'
import { Button, Card } from 'react-bootstrap'
import { render } from 'react-dom'

// Modal for when a user clicks on a Title



function CreatePop({ createRev } ) {
    if (createRev !== null) {
        // pass in user's review data to ratingreview if there is any
        return (< RatingReview  > Rating review section for specific title </RatingReview >);
    }
    else { return (<br />); }
}


// props = api data
export default function Title() {
    const [createRev, setCreate] = useState(null);
    const hasUserReview = false;
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
                <Button style={{ color: "white" }} onClick={createReview}>Create/Update a review</Button>
                <CreatePop createRev={createRev}/>
                </div>
        </>
    )
    
    function createReview() {
        if (createRev != null) {
            setCreate(null);
        }
        else {
            setCreate(true);
        }
    }


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





