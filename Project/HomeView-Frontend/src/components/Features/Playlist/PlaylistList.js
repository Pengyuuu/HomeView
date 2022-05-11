import React, {useState, useEffect} from "react";
import {Button, Modal} from 'react-bootstrap';
import PlaylistListTitle from "./PlaylistListTitle";

export default function PlaylistList(playlist) {

    const [show, setShow] = useState(false);

    const [data, setData] = useState([playlist]);

    const [titles, setTitles] = useState([]);

    const handleClose = () => { setShow(false); }

    const handleShow = () => { setShow(true); }

    useEffect(() => {

        data.map((playlist) => ( setTitles(playlist.playlist.titles) ))
    }, []);
    return (
        <div>
            <Button onClick={() => handleShow()}> 
                {playlist.playlist.playlistName} 
            </Button>
            <Button variant="outline-danger">Remove</Button>

            <Modal show={show} onHide={() => handleClose()}>
                <Modal.Title>
                    <Modal.Header>
                        {playlist.playlist.playlistName}
                    </Modal.Header>
                </Modal.Title>
                <Modal.Body>
                    {titles.map((title) => (
                        <PlaylistListTitle title={title} />
                    ))}
                </Modal.Body>
            </Modal>
        </div>
    )

}