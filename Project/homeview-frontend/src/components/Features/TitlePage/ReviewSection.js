import React, {useEffect, useState} from 'react';
import axios from 'axios';
import ReviewItem from './ReviewItem'
    

    function ReviewSection({selectedTitle}) {
        const [ reviews, setReviews ] = useState([]);
        
        const HOMEVIEW_API = {
            method: 'GET',
            url: 'https://homeview.me/reviews/get',
            params: {
                selectedTitle
            }
        }
        /**
        useEffect(() => {
            axios.request(HOMEVIEW_API).then(function (response) {
                console.log(response.data);
                setReviews(response.data.results);
            }).catch(function (error) {
                console.error(error);
            });
        }, []);
        **/
        //setReviews

        return (
            <div >
                <h3>Review Section</h3>
                <br></br>
                {reviews.length > 0 && reviews.map((review) =>(
                    <ReviewItem key={review.dispName} {...review} />  
                ))}
                <br></br>
            </div>
        );
    }


export default ReviewSection