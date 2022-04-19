import React from 'react'
import '../../../css/App.css'
import RatingReview from './RatingReview'
import { Button, Modal } from 'react-bootstrap'
import { render } from 'react-dom'

const IMG_API = "https://image.tmdb.org/t/p/original/"

export default function TitleModal(props) {

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
                        + props.posterurl}></img>
                </div>
                <div className="title-details">
                <p >{props.year}</p>
                <p>{props.imdbRating}</p>
                <p>{props.streamingInfo}</p>
                <p>{props.genres}</p>
                    <p>{props.cast}</p>
                    <p>{props.overview}</p>

                    </div>
            </Modal.Body>
            <Modal.Footer>
                <Button onClick={props.onHide}>Close</Button>
            </Modal.Footer>
        </Modal>
    );
}