import axios from 'axios';
import React, {useState} from 'react';
import {Button, Modal} from 'react-bootstrap';

function WatchLaterList() {

    const email = "testing@gmail.com";

    const [show, setShow] = useState(false);

    const [data, setData] = useState([]);

    const handleClose = () => { setShow(false); };

    const handleShow = () => { setShow(true); };

    const WATCHLATER_API_GET = {
        method: 'get',
        url: `http://54.219.16.154/api/WatchLater/${email}`,
        headers: { }
    };

    function Get() {
        axios.request(WATCHLATER_API_GET).then(function (response) {
            setData(response.data);
        }).catch(function (error) {
            console.error(error);
        });
    }

    function WatchLater({title, year}) {
        return (
            <li>
                {title} {(year)}
            </li>
        )
    }

    return(
        <>
            <Button onClick={()=> {handleShow(); Get(); }}>Watch Later</Button>

            <Modal show={show} onHide={()=>handleClose()}>
                <Modal.Title>
                    <Modal.Header>
                        Your Watch Later List
                    </Modal.Header>
                </Modal.Title>
                <Modal.Body>
                    {data.length > 1 && data.map((title) => (
                        <WatchLater title={title.title} year={title.year} />
                    ))}
                </Modal.Body>
            </Modal>
        </>
    )
}
export default WatchLaterList