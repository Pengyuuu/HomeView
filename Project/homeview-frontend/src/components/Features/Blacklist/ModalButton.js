import React, {useState} from "react";
import {Button, Modal} from 'react-bootstrap'

function ModalButton({items}) {

    const [show, setShow] = useState(false);
    const [item, setItem] = useState();

    const handleClose = () => {
        setShow(false);
    };
    const handleShow = () => {
        setShow(true);
    };

    console.log(items)
    return(
        <>
        {items.length > 0 && items.map((item) => 
        <Button key = {item}  onClick={handleShow}>
            {item}
        </Button>)}
        
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title id = "contained-modal-title-vcenter">
                    Blacklist
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Button>Add to Blacklist</Button>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    Close
                </Button>
            </Modal.Footer>
        </Modal>
        </>


    );
}
//<p>Genres: {genres.map((genre) => <Button>{genre}</Button>)}</p>
export default ModalButton;