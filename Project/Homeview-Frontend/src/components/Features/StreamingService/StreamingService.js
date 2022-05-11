import React, { useState, useEffect } from 'react'
import { Card } from 'react-bootstrap'
import axios from 'axios';
import Navigation from '../../Navigation'
import LogAccess from '../../Core/LogAccess'
//<script src='/Core/Security.js'></script>
const COUNTRIES_API = {
    method: 'GET',
    url: 'https://streaming-availability.p.rapidapi.com/countries',
    headers: {
        'X-RapidAPI-Host': 'streaming-availability.p.rapidapi.com',
        'X-RapidAPI-Key': 'cc4a9a7618msh29ea64bd110ca53p17eeefjsncd4c7af4a976'
    }
};

function StreamingService() {
    const STREAMING_VIEW_ID = 6;
    LogAccess(STREAMING_VIEW_ID);

    const [streamService, setStreamService] = useState([]);
    const [selectedCountries, setSelectedCountries] = useState([]);

    useEffect(() => {

        axios.request(COUNTRIES_API).then(function (response) {
            setStreamService(response.data);
        }).catch(function (error) {
            console.error(error);
        });
    }, []);
    return (
        <div>
            <Navigation />
            <div className="container p-5">
                <div className='card-center'>
                    <Card>
                        <select className="custom-select" onChange={(e) => {
                            const countries = e.target.value;
                            setSelectedCountries(countries)
                        }}>
                            <option selected="true" disabled="disabled">
                                Select A Streaming Service</option>
                            {Object.keys(streamService).map(element =>
                                <option key={element} value={streamService[element]}>{element}</option>)}
                        </select>
                        <p>Supported Countries: {selectedCountries}</p>
                    </Card>
                </div>
            </div>
        </div>
    )

}

export default StreamingService
