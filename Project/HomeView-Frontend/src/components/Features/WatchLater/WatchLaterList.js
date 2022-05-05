import React, {useState} from 'react';
import {Button, Modal} from 'react-bootstrap';

export default function WatchLaterList() {

    const [show, setShow] = useState(false);

    const handleClose = () => { setShow(false); }

    const handleShow = () => { setShow(true); }

    return (
        <div>
            <Button onClick={handleShow()}>Watch Later</Button>

            <Modal show={show} onHide={handleClose()}>

            </Modal>
        </div>
    )
}