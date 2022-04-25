import React from 'react';
//import './../../css/movietile.css';


const ReviewItem = ({ rating, review, dispName }) => {
    return (<>

        <div>
            <div>
                <h6>{dispName} - {rating} / 5</h6>
                <p>{review}</p>
            </div>
        </div>
        </>
    )
}

export default ReviewItem;