import React, { useState } from 'react';
import './../../css/movietile.css';
import { Button, Modal } from 'react-bootstrap';
//import  ReviewSection  from './../Features/TitlePage/ReviewSection'
import  ReviewItem  from './../Features/TitlePage/ReviewItem'

import axios from 'axios';
import GenreList from './MovieList'
import './../../css/Modal.css';


const IMG_API = "https://image.tmdb.org/t/p/original/"

const Movie = ({ title, posterPath, overview, year, imdbRating, streamingInfo, genres, cast }) => {
    
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    //const [reviews, setReviews] = useState([]);
    //const handleReviews = (val) => setReviews(val);

    /*
    const [reviews, setReviews] = useState([]);
    const loadReviews = () => {
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
        return titleReviews;
    };
    var revList = loadReviews();
    var avgRating = revList.rating;
    setReviews(revList.ratingAndReviews);


    <br></br>
        {
    reviews.length > 0 && reviews.map((review) => (
        <ReviewItem key={review.dispName} {...review} />
            ))
        }
        <br></br> 
*/
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
    const r = titleReviews.ratingAndReviews;
    //handleReviews(r);
    console.log(r);
   

    return (
    <>
        <div className='movie' onClick={handleShow}>
            <img src={IMG_API + posterPath} alt={title} />
            <div className='img-overlay img-overlay--blur'>
                <div className="movie-title">{title}</div>
                <p className='overview'>{overview}</p>
            </div>
        </div>

        <Modal show={show} onHide={handleClose} aria-labelledby="contained-modal-title-vcenter" size="lg">
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">
                    {title}
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <div>
                    <img className="title-img" src={IMG_API + posterPath}></img>
                </div>
                <div className="title-details">
                <p>Year: {year}</p>
                <p>Rating: {imdbRating}</p>
                <p>Streaming Service: {Object.keys((streamingInfo))}</p>
                <p>Genres: {genres}</p>
                        <p>Actors: {cast}</p>

                </div>
                <div >
                    <h3>Review Section</h3>
                    <p> Average Rating:  </p>
                </div>

            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    Close
                </Button>
            </Modal.Footer>
        </Modal>
    </>
    )
}




export default Movie;