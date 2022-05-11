import React, {useState} from "react";
import {Button, Modal} from 'react-bootstrap';

export default function PlaylistList(playlist) {

    const [show, setShow] = useState(false);

    const handleClose = () => { setShow(false); }

    const handleShow = () => { setShow(true); }

    return (
        <div>
            <Button onClick={() => handleShow()}> 
                {playlist.playlist.playlistName} 
            </Button>

            <Modal show={show} onHide={() => handleClose()}>
                <Modal.Title>
                    <Modal.Header>
                        {playlist.playlist.playlistName}
                    </Modal.Header>
                </Modal.Title>
                <Modal.Body>
                </Modal.Body>
            </Modal>
        </div>
    )

}