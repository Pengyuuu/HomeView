import React, { useState } from 'react'
import '../../../css/App.css'
import RatingReview from './RatingReview'
import { Button, Image, Modal } from 'react-bootstrap'
import { render } from 'react-dom'

export default function TitleModal(props) {
    console.log(props.props.title);
    return (
        <Modal {...props} aria-labelledby="contained-modal-title-vcenter" size="lg">
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">
                    {props.props.title}
                </Modal.Title>
            </Modal.Header>
            <Modal.Body  >
                <div>
                    <img className="title-container" src={props.props.imgsrc}></img>
                </div>
                <div className="title-details">
                <p >{props.props.year}</p>
                <p>{props.props.hvRating}</p>
                <p>{props.props.services}</p>
                <p>{props.props.genres}</p>
                    <p>{props.props.actors}</p>
                    </div>
            </Modal.Body>
            <Modal.Footer>
                <Button onClick={props.onHide}>Close</Button>
            </Modal.Footer>
        </Modal>
    );
}