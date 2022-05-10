import axios from 'axios';
import React, { useState } from 'react';
import { Button, Modal } from 'react-bootstrap';
import ReviewItem from './ReviewItem';

function ReviewList() {

    const dispName = "testName";

    const [show, setShow] = useState(false);

    const [data, setData] = useState([]);

    const handleClose = () => { setShow(false); };

    const handleShow = () => { setShow(true); };

    const WATCHLATER_API_GET = {
        method: 'get',
        url: `http://54.219.16.154/api/RatingReview/get/user/reviews/${dispName}`,
        headers: {}
    };

    function Get() {
        axios.request(WATCHLATER_API_GET).then(function (response) {
            setData(response.data);
        }).catch(function (error) {
            console.error(error);
        });
    }

    return (
        <>
            <Button onClick={() => { handleShow(); Get(); }}>Review List</Button>

            <Modal show={show} onHide={() => handleClose()}>
                <Modal.Title>
                    <Modal.Header>
                        Your Reviews List
                    </Modal.Header>
                </Modal.Title>
                <Modal.Body>
                    {data.length > 1 && data.map((rev) => (
                        <ReviewItem title={rev.title} rating={rev.rating} review={rev.review} dispName={dispName} />
                    ))}
                </Modal.Body>
            </Modal>
        </>
    )

}
export default ReviewList