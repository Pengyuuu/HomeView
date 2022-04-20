import React, {useEffect, useState} from 'react';
import axios from 'axios';
import ReviewItem from './ReviewItem'
import RatingReview from './RatingReview'
import { Button } from 'react-bootstrap';
import '../../../css/App.css'



function ReviewSection({ average, reviewList, show }) {
    const [createRev, setCreate] = useState(null);
    const handleClose = () => {
        setCreate(false);
    };
    const handleShow = () => {
        setCreate(true);
    };


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
            return (< RatingReview  > Rating review section for specific title </RatingReview >);
        }
        else { return (<br />); }
    }

    function deleteReview() {
        // call delete api
        return false;
    }

    if (show) {
        return (
            <div >
                <h5>Review Section</h5>
                <p> Average Rating: {average} </p>
                <Button class="mr-1" style={{ color: 'white' }} onClick={createReview}>Create/Update a review</Button>
                <Button class="mr-1" style={{ backgroundColor: 'red', color:'white' }} onClick={deleteReview}>Delete a review</Button>
                <CreateReview createRev={createRev} />
                {reviewList.length > 0 && reviewList.map((review) => (
                    <ReviewItem key={review.dispName} {...review} />
                ))}
            </div>
        );
    }
    else {
        return null;
    }
}

export default ReviewSection