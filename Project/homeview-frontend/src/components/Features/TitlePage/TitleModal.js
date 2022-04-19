import React, {useState} from 'react'
import '../../../css/App.css'
import RatingReview from './RatingReview'
import ReviewSection from './ReviewSection'
import { Button, Modal } from 'react-bootstrap'

const IMG_API = "https://image.tmdb.org/t/p/original/"

function CreateReview({ createRev } ) {
    if (createRev !== null) {
        // pass in user's review data to ratingreview if there is any
        return (< RatingReview  > Create Rating Review</RatingReview >);
    }
    else { return (<br />); }
}

export default function TitleModal(props) {
    const [createRev, setCreate] = useState(null);
    function checkCreate() {
        if (createRev != null) {
            setCreate(null);
        }
        else {
            setCreate(true);
        }
    }
    
    return (
        <Modal {...props} aria-labelledby="contained-modal-title-vcenter" size="lg">
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">
                    {props.title}
                </Modal.Title>
            </Modal.Header>
            <Modal.Body  >
                <div>
                    <img className="title-container" src={IMG_API 
                        + props.posterurl} alt={props.title}></img>
                </div>
                <div className="title-details">
                <p >{props.year}</p>
                <p>{props.imdbRating}</p>
                <p>{props.streamingInfo}</p>
                <p>{props.genres}</p>
                    <p>{props.cast}</p>
                    <p>{props.overview}</p>

                    </div>
                <Button style={{ color: "white" }} onClick={checkCreate}>Create/Update a review</Button>
                <CreateReview createRev={createRev}/>
                <ReviewSection/>
            </Modal.Body>
            <Modal.Footer>
                <Button onClick={props.onHide}>Close</Button>
            </Modal.Footer>
        </Modal>
    );
}


