import axios from 'axios';
import { Form, Button, Card } from 'react-bootstrap'
import React, { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom';
import Navigation from '../../Navigation'
import LogAccess from '../../Core/LogAccess'

//<script src='/Core/Security.js'></script>
const ActWiki = ({ }) => {
    const ACT_VIEW_ID = 5;
    LogAccess(ACT_VIEW_ID);

    const [actDetails, setActDeatails] = useState([]);
    console.log(GetAct("Megan Fox"));
    console.log(actDetails);

    return (
        <>
            <Navigation />
            <div className="container">
                <div className='card-center'>
                    <Card>
                        <Card.Body>
                            <h2 className="text-center"> Actors / Actress </h2>
                            <Form>
                                <input type='text' placeholder='Search...' className='search'></input>
                            </Form>
                        </Card.Body>
                    </Card>
                </div>
            </div>
        </>
    )

    function GetAct(actName) {
        useEffect(() => {
            let axios = require("axios");
            let config = {
                method: 'get',
                url: "https://api.themoviedb.org/3/search/person?api_key=" +
                    "82da0caf88a6e84985e9fe3d753d6f43&language=en-US" +
                    "&query=" + actName + "&page=1&include_adult=false",
                headers: {}

            };
            axios(config)
                .then(function (response) {
                    setActDeatails(response.data.results[0]);
                })

        }, []);
    }

    /*
    .then(function (actObj) {
        var actInfo = actObj;
        return fetch(`https://api.themoviedb.org/3/person/${actInfo.id}?  
        api_key=${process.env.REACT_APP_TMDB_API_KEY}&language=en-US`)
        .then(function(result){
            return result.json();
        })
    })
    */

}
export default ActWiki



