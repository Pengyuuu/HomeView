import React, {useEffect, useState} from 'react';
import axios from 'axios';
import Movie from './MovieTile';
import './../../css/movietile.css';
import TitleModal from '../../components/Features/TitlePage/TitleModal'


    const HOMEVIEW_API = {
        method: 'GET',
        url: 'https://homeview.me/reviews/get',
        params: {
            selectedTitle
        }
    }

    function ReviewSection() {
        const [ reviews, setReviews ] = useState([]);
        

        useEffect(() => {
            axios.request(HOMEVIEW_API).then(function (response) {
                console.log(response.data);
                setReviews(response.data.results);
            }).catch(function (error) {
                console.error(error);
            });
        }, []);

        return (
            <div >
                {reviews.length > 0 && reviews.map((review) =>(
                    <ReviewItem key={review.dispName} {...review} onClick={handleState} />  
                ))}
            </div>
        );
    }


export default ReviewSection