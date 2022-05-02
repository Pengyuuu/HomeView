import React, {useState} from "react";
import {Button, Modal} from 'react-bootstrap'
import axios from 'axios'

function ModalButton({items}) {

    const [item, setItem] = useState();
    const [show, setShow] = useState(false);
    

    const handleClose = () => {
        setShow(false);
    };
    const handleShow = () => {
        setShow(true);
    };


    //console.log(items)
    // for each item (actor/genre), map as a button w/ onclick to show modal
    return(
        <>
        {items.length > 0 && items.map((item) => 
        <Button className="blacklist-item-btn" key = {item}  onClick={()=>{handleShow(); setItem(item);}}>
            {item}
            
        </Button>)}
        
        <Modal show={show} onHide={()=>handleClose()}>
            <Modal.Header closeButton>
                <Modal.Title id = "contained-modal-title-vcenter">
                    Blacklist
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Button className="blacklist-add-btn" onClick={()=>{Add(item)}} >Add {item} Blacklist</Button>
                {console.log(item)}
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={()=>{handleClose()}}>
                    Close
                </Button>
            </Modal.Footer>
        </Modal>
        </>


    );
}

// post, adds item to blacklist
function Add(item) {
    var axios = require('axios');
    var data = JSON.stringify({
    "blacklistItem": ""+item,
    "dispName": "HankHill@yahoo.com"
    });

    var config = {
    method: 'post',
    url: 'http://54.219.16.154/api/blacklist/',
    headers: { 
        'Content-Type': 'application/json'
    },
    data : data
    };

    axios(config)
    .then(function (response) {
    console.log(JSON.stringify(response.data));
    alert("added")
    })
    .catch(function (error) {
    console.log(error);
    });
}

export default ModalButton;