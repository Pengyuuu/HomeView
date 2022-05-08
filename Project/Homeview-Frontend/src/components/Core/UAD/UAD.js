// React imports
import React, { useState, useEffect } from 'react';
// Custom and styling
import Navigation from '../../Navigation';
import './../../../css/news.css';
import TrendGraph from './TrendGraph';

//<script src='/Core/Security.js'></script>

/* export is used for js modules (when importing from other files) */
const UAD = () => {

    /* useState automatically creates a state variable (data), and its mutator (setData)
     * setData renders the page on state change */
    const [data, setData] = useState(["Loading..."]);
    /**
    useEffect(() => {
        let axios = require('axios');

        let config = {
            method: 'get',
            url: 'http://54.219.16.154/api/uad',
            headers: {}
        };

        axios(config)
            .then(function (response) {
                setData(response.data);
            })
            .catch(function (error) {
                console.log(error);
            });

    }, []);**/
    /* useEffect is executed every time a state inside [] is changed (ie [data])
     * leave blank [] to only execute once and prevent calling API every state change*/

    /* length check to ensure it doesn't try generating initial "Loading..." val */
    setData([0, 1, 0, 2, 0, 5, 1]);


    console.log(data);
    return (
        <div >
            <Navigation />
            <h1>Usage Analysis Dashboard (UAD)</h1>
            <div>
                <TrendGraph data = {data} />

            </div>
        </div>
    );
}

export default UAD;