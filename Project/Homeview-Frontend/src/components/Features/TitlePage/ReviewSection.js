import React, {useEffect, useState} from 'react';
import axios from 'axios';
import ReviewItem from './ReviewItem'
    

function ReviewSection({ average, reviewList, show }) {
    if (show) {
        return (
            <div >
                <h5>Review Section</h5>
                <p> Average Rating: {average} </p>
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