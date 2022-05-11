import React, {useState} from "react"
import { Button, Modal } from 'react-bootstrap';
import axios from 'axios';
import WatchLater from "../Features/WatchLater/WatchLater";
import ReviewSection from "../Features/RatingReview/ReviewSection";
import ModalButton from "../Features/Blacklist/ModalButton";
import './../../css/popularseriestile.css'


const IMG_API = "https://image.tmdb.org/t/p/original/"

const PopularSeriesTile = ({genre_ids, name, first_air_date, overview, vote_average, poster_path}) => {
    
    const [show, setShow] = useState(false);
    const [reviews, setReviews] = useState([]);

    const dispNameTest = 'testName';
    const GET_URL = 'http://54.219.16.154/api/RatingReview/get/title/' + name;
    const REVIEW_API_GET = {
        method: 'get',
        url: GET_URL,
        headers: {}
    };

    function getReviewList() {
        axios.request(REVIEW_API_GET).then(function (response) {
            console.log(response.data);
            setReviews(response.data);
        }).catch(function (error) {
            console.error(error);
        });
    };

    const handleClose = () => {
        setShow(false);
        setReviews([]);
    };
    const handleShow = () => {
        setShow(true);
        getReviewList();
    };

    return (
        <>
        <div className='p-movie' onClick={handleShow}>
            <img src={IMG_API + poster_path} alt={name} />
            <div className='img-overlay img-overlay--blur'>
                <div className="movie-title">{name}</div>
                <p className='overview'>{overview}</p>
            </div>
        </div>
        <Modal show={show} onHide={handleClose} aria-labelledby="contained-modal-title-vcenter" size="lg">
                <Modal.Header closeButton>
                    <Modal.Title id="contained-modal-title-vcenter">
                        {name}
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <div>
                        <img className="title-img" src={IMG_API + poster_path}></img>
                    </div>
                    <div className="title-details">
                        <p>Year: {first_air_date}</p>
                        <p>Rating: {vote_average}</p>
                        <p>Overview: {overview}</p>
                        <p>Genres: <ModalButton items={genre_ids}/></p>                        
                    </div>
                    <ReviewSection title={name} average={reviews.rating} reviewList={reviews.ratingAndReviews} show={show} />
                    <WatchLater title={name} year={first_air_date} />

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

export default PopularSeriesTile