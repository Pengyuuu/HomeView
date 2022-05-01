import React, {useState} from "react";
import {Button, Modal} from 'react-bootstrap'

function AccountButton() {
    const [show, setShow] = useState(false);

    const handleClose = () => {
        setShow(false);
    };
    const handleShow = () => {
        setShow(true);
    };
    return(
        <>
        <Button onClick={handleShow}>
            Show Blacklist
        </Button>
        
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title id = "contained-modal-title-vcenter">
                    Your Blacklist
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                Lists of Blacklists here
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

export default AccountButton