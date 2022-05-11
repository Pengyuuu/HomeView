import React, { useState, useEffect } from "react";
import { Button, Modal } from 'react-bootstrap'
import axios from 'axios';
import { callbackify } from "util";

const BLACKLIST_API_GET = {
    method: 'get',
    url: 'http://54.219.16.154/api/blacklist/?selectedUser=HankHill@yahoo.com',
    headers: {}
};


function AccountButton() {
    const [show, setShow] = useState(false);
    const [data, setData] = useState(["Loading..."]);

    // arrow func sets states to false/true when called
    const handleClose = () => {
        setShow(false);
    };
    const handleShow = () => {
        setShow(true);
    };

    // calls get blacklists
    function Get() {
        axios.request(BLACKLIST_API_GET).then(function (response) {
            //console.log(response.data);
            setData(response.data);
        }).catch(function (error) {
            console.error(error);
        });
    }


    // loops through blacklist array and displays each item as blacklist component
    // which is a <li> and a button
    return (
        <>
            <Button onClick={() => { handleShow(); Get() }}>
                Show Blacklist
            </Button>

            <Modal show={show} onHide={() => handleClose()}>
                <Modal.Header closeButton>
                    <Modal.Title id="contained-modal-title-vcenter">
                        Your Blacklist
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    {data.length > 1 && data.map((item) => (
                        <Blacklist key={item.blacklistItem} item={item.blacklistItem} />))
                    }
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="primary" onClick={() => { Enable() }}>

                        Enable
                    </Button>

                    <Button variant="danger" onClick={() => { Disable() }}>

                        Disable
                    </Button>

                    <Button variant="secondary" onClick={() => handleClose()}>
                        Close
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    )
}

function Blacklist({ item }) {
    return (
        <li>
            {item}
            <Button variant="outline-danger" size="sm" onClick={() => Remove(item)}> Remove </Button>
        </li>

    )
}


// web api call to remove / delete
function Remove(item) {
    var axios = require('axios');
    var data = JSON.stringify({
        "blacklistItem": "" + item,
        "dispName": "HankHill@yahoo.com"
    });

    var config = {
        method: 'delete',
        url: 'http://54.219.16.154/api/blacklist/',
        headers: {
            'Content-Type': 'application/json'
        },
        data: data
    };

    axios(config)
        .then(function (response) {
            console.log(JSON.stringify(response.data));
            alert("removed")
        })
        .catch(function (error) {
            console.log(error);
        });
}

// web api disable and enable calls
function Disable() {

    { console.log(false) }

    var axios = require('axios');
    var data = JSON.stringify({
        "dispName": "HankHill@yahoo.com",
        "blacklistToggle": false
    });

    var config = {
        method: 'put',
        url: 'http://54.219.16.154/api/blacklist/',
        headers: {
            'Content-Type': 'application/json'
        },
        data: data
    };

    axios(config)
        .then(function (response) {
            console.log(JSON.stringify(response.data));
            alert("disabled")
        })
        .catch(function (error) {
            console.log(error);
        });

}

function Enable() {

    { console.log(true) }

    var axios = require('axios');
    var data = JSON.stringify({
        "dispName": "HankHill@yahoo.com",
        "blacklistToggle": true
    });

    var config = {
        method: 'put',
        url: 'http://54.219.16.154/api/blacklist/',
        headers: {
            'Content-Type': 'application/json'
        },
        data: data
    };

    axios(config)
        .then(function (response) {
            console.log(JSON.stringify(response.data));
            alert("enabled")
        })
        .catch(function (error) {
            console.log(error);
        });

}

export default AccountButton