import React, {useState, useEffect} from "react";
import {Button, Modal} from 'react-bootstrap'
import axios from 'axios'

function ModalButton({items}) {

    const [item, setItem] = useState();
    const [show, setShow] = useState(false);
    //const [genres, setGenres] = useState([]);
    const realItems = []

    const genres = {"1":"Biography","10402":"Music","10749":"Romance","10751":"Family","10752":"War","10763":"News","10764":"Reality","10767":"Talk Show","12":"Adventure","14":"Fantasy","16":"Animation","18":"Drama","2":"Film Noir","27":"Horror","28":"Action","3":"Game Show","35":"Comedy","36":"History","37":"Western","4":"Musical","5":"Sport","53":"Thriller","6":"Short","7":"Adult","80":"Crime","878":"Science Fiction","9648":"Mystery","99":"Documentary"}

    const handleClose = () => {
        setShow(false);
    };
    const handleShow = () => {
        setShow(true);
    };

    useEffect(() => {
        const options = {
        method: 'GET',
        url: 'https://streaming-availability.p.rapidapi.com/genres',
        headers: {
            'X-RapidAPI-Host': 'streaming-availability.p.rapidapi.com',
            'X-RapidAPI-Key': 'cc4a9a7618msh29ea64bd110ca53p17eeefjsncd4c7af4a976'
        }
        };

    }, []);
    
    {items.forEach (item => 
        {for (const [key, value] of Object.entries(genres)) {
            if (key == item) {
                realItems.push(value)
            }
        }}
    )}
    
    console.log(realItems)
    

    //console.log(items)
    // for each item (actor/genre), map as a button w/ onclick to show modal
    return(
        <>
        
        {realItems.length > 0 && realItems.map((item) => 
        <Button className="blacklist-item-btn" key = {item}  onClick={()=>{handleShow(); setItem(item);}}>
            {item}
            
        </Button>)}
        
        
        <Modal show={show} onHide={()=>handleClose()}>
            <Modal.Header closeButton>
                <Modal.Title id = "contained-modal-title-vcenter">
                    Blocklist
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Button className="blacklist-add-btn" onClick={()=>{Add(item)}} >Add {item} to Blocklist</Button>
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
    "dispName": "may@yahoo.com"
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
    alert("unable to add")
    });
}

export default ModalButton;