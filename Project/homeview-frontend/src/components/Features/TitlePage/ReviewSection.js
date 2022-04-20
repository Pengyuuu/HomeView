import React, {useEffect, useState} from 'react';
import axios from 'axios';
import ReviewItem from './ReviewItem'
    

    function ReviewSection() {
        const [ reviews, setReviews ] = useState([]);
        /**
        const HOMEVIEW_API = {
            method: 'GET',
            url: 'https://homeview.me/reviews/get',
            params: {
                selectedTitle
            }
        }**/
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
        var titleReviews = {
            "rating": 4,
            "ratingAndReviews": [
                {
                    "rating": 4,
                    "review": "???",
                    "title": "Power Rangers",
                    "dispName": "HankHill@yahoo.com"
                }
            ]
        };
        console.log(titleReviews);
        var reviewList = titleReviews.ratingAndReviews;
        console.log(reviewList);
        setReviews(reviewList);
        console.log(reviews);

        return (
            <div >
                <h3>Review Section</h3>
                <p> Average Rating: {titleReviews.rating} </p>
                <br></br>
                {reviews.length > 0 && reviews.map((review) =>(
                    <ReviewItem key={review.dispName} {...review} />  
                ))}
                <br></br>
            </div>
        );
    }


export default ReviewSection