import React, {useState, useEffect} from "react";
import {Button, Modal} from 'react-bootstrap'
import axios from 'axios';
import { callbackify } from "util";

const BLACKLIST_API_GET = {
    method: 'get',
    url: 'http://54.219.16.154/api/blacklist/?selectedUser=HankHill@yahoo.com',
    headers: { }
};


function AccountButton() {
    const [show, setShow] = useState(false);
    const [data, setData] = useState(["Loading..."]);

    const handleClose = () => {
        setShow(false);
    };
    const handleShow = () => {
        setShow(true);
    };


    function callGET() {
        axios.request(BLACKLIST_API_GET).then(function (response) {
            //console.log(response.data);
            setData(response.data);
        }).catch(function (error) {
            console.error(error);
        });
    }



    return(
        <>
        <Button onClick={()=>{handleShow(); callGET()}}>
            Show Blacklist
        </Button>
        
        <Modal show={show} onHide={()=>handleClose()}>
            <Modal.Header closeButton>
                <Modal.Title id = "contained-modal-title-vcenter">
                    Your Blacklist
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                {data.length > 1 && data.map((item) => (
                <Blacklist key={item.blacklistItem} item={item.blacklistItem} />))
                }
            </Modal.Body>
            <Modal.Footer>
                <Button variant = "primary" onClick={()=>{enable()}}>
                    
                    Enable
                </Button>

                <Button variant = "danger" onClick={()=>{disable()}}>
                    
                    Disable
                </Button>

                <Button variant="secondary" onClick={()=>handleClose()}>
                    Close
                </Button>
            </Modal.Footer>
        </Modal>
        </>
    )
}

function Blacklist({item}) {
    return (
        <li>
            {item}
            <Button variant="outline-danger" size="sm" onClick={() => Remove(item)}> Remove </Button>
        </li>
        
    )
}



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
    data : data
    };

    axios(config)
    .then(function (response) {
    console.log(JSON.stringify(response.data));
    })
    .catch(function (error) {
    console.log(error);
    });
}

function disable() {

    {console.log(false)}

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
    data : data
    };

    axios(config)
    .then(function (response) {
    console.log(JSON.stringify(response.data));
    })
    .catch(function (error) {
    console.log(error);
    });

}

function enable() {

    {console.log(true)}

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
    data : data
    };

    axios(config)
    .then(function (response) {
    console.log(JSON.stringify(response.data));
    })
    .catch(function (error) {
    console.log(error);
    });

}

export default AccountButton