import React from 'react';

// Page for when a user clicks on a Title
// props = api data
function Title(props) {

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
    )
}


