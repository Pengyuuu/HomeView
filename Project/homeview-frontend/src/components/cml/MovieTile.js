import React, { useState } from 'react';
import './../../css/movietile.css';
import { Button, Modal } from 'react-bootstrap';
import  ReviewSection  from './../Features/TitlePage/ReviewSection'
//import  ReviewItem  from './../Features/TitlePage/ReviewItem'
import BlacklistButton from './../Features/Blacklist/ModalButton'

import axios from 'axios';
import GenreList from './MovieList'
import './../../css/Modal.css';


const IMG_API = "https://image.tmdb.org/t/p/original/"


const Movie = ({ title, posterPath, overview, year, imdbRating, streamingInfo, genres, cast }) => {
    
    const [show, setShow] = useState(false);
    const [reviews, setReviews] = useState([]);

    let titleReviews = [];
    const dispNameTest = 'testName';
    const testTitle = 'Power Rangers';
    const GET_URL = 'http://myhomeview.me/api/RatingReview/submit/' + title

    const testtitleReviews = {
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
    



    const handleClose = () => {
        setShow(false);
        setReviews([]);
    };
    const handleShow = () => {
        setShow(true);
        setReviews(testtitleReviews);

/** 
        fetch(GET_URL, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(res => {
            console.log(res)
            //titleReviews = res.json()
        })
            .then(data => console.log(titleReviews))
        setReviews(testtitleReviews);
         */
    };

   
    // use blacklistbutton/modalbutton func to make genres and cast buttons
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
                <p>Genres: <BlacklistButton items = {genres}/></p>
                        <p>Actors: <BlacklistButton items = {cast}/></p>
                </div>
                    <ReviewSection average={reviews.rating} reviewList={reviews.ratingAndReviews} show={show}/>

            </Modal.Body>
            <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose} >
                    Close
                </Button>
            </Modal.Footer>
        </Modal>
    </>
    )


}


export default Movie;