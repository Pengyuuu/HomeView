import axios from "axios";
import React, {useState} from "react";
import { Button, Modal } from "react-bootstrap";
import AddToList from "./AddToList";

export default function AddToPlaylist() {

    const [data, setData] = useState([]);

    const [show, setShow] = useState(false);

    const handleClose = () => { setShow(false); };

    const handleShow = () => { setShow(true); };

    function Get() {

        const email = "may@gmail.com"

        const PLAYLIST_API_GET = {
            method: 'get',
            url: `http://54.219.16.154/get/playlist/${email}`,
            headers: { }
        };

        axios.request(PLAYLIST_API_GET).then(function (response) {
            setData(response.data);
        }).catch(function (error) {
            console.error(error);
        });
    }

    return (
        <>
            <Button onClick={() => {handleShow(); Get(); }}>Add To Playlist</Button>

            <Modal show={show} onHide={() => handleClose()}>
                <Modal.Title>
                    <Modal.Header>
                        Your Playlists
                    </Modal.Header>
                </Modal.Title>
                <Modal.Body>
                    {data.length > 0 && data.map((playlist) => (
                        <AddToList playlist={playlist} />
                    ))}
                </Modal.Body>
            </Modal>
        </>
    )
}