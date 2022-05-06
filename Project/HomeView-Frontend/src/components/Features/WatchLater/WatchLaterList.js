import React, {useState} from 'react';
import {Button, Modal} from 'react-bootstrap';

function WatchLaterList() {

    const [show, setShow] = useState(false);

    const handleClose = () => { setShow(false); };

    const handleShow = () => { setShow(true); };

    return(
        <>
            <Button onClick={()=> {handleShow()}}>Watch Later</Button>

            <Modal show={show} onHide={()=>handleClose()}>
            <Modal.Body>
                Hello
            </Modal.Body>
            </Modal>
        </>
    )
}
export default WatchLaterList