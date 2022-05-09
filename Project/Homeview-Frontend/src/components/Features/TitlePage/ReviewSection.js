import React, { useEffect, useState } from 'react';
import axios from 'axios';
import ReviewItem from './ReviewItem'
import RatingReview from './RatingReview'
import { Button } from 'react-bootstrap';
import '../../../css/App.css'



function ReviewSection({ title, average, reviewList, show }) {
    const [createRev, setCreate] = useState(null);

    function createReview() {
        if (createRev != null) {
            setCreate(null);
        }
        else {
            setCreate(true);
        }
    }

    function CreateReview({ createRev }) {
        if (createRev !== null) {
            return (< RatingReview title={title}> Rating review section for specific title </RatingReview >);
        }
        else { return (<br />); }
    }

    function deleteReview() {
        const dispNameTest = 'testName'
        const DELETE_URL = 'http://54.219.16.154/api/RatingReview/delete/title/user/' + title + '/' + dispNameTest

        fetch(DELETE_URL, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(res => {
            console.log(res)
            return res.json()
        })
            .then(data => console.log("reach"))
        return true;
    }

    if (show) {

        if (reviewList !== undefined) {
            console.log({ reviewList });

            return (
                <div >
                    <h5>Review Section</h5>
                    <p> Average Rating: {average} </p>
                    <Button className="mr-1" style={{ color: 'white' }} onClick={createReview}>Create/Update a review</Button>
                    <Button className="mr-1" style={{ backgroundColor: 'red', color: 'white' }} onClick={deleteReview}>Delete a review</Button>
                    <CreateReview createRev={createRev} />
                    {reviewList.length > 0 && reviewList.map((review) => (
                        <ReviewItem key={review.dispName} {...review} />
                    ))}
                </div>
            );
        }
        else {
            return (
                <div >
                    <h5>Review Section</h5>
                    <p> Average Rating: {average} </p>
                    <Button className="mr-1" style={{ color: 'white' }} onClick={createReview}>Create/Update a review</Button>
                    <Button className="mr-1" style={{ backgroundColor: 'red', color: 'white' }} onClick={deleteReview}>Delete a review</Button>
                    <CreateReview createRev={createRev} />
                </div>
            );
        }
    }
    else {
        return null;
    }
}

export default ReviewSection