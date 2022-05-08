// React imports
import React, { useState, useEffect } from 'react';
// Custom and styling
import Navigation from '../../Navigation';
import TrendGraph from './TrendGraph';
import BarGraph from './BarGraph';
import '../../../css/uad.css'


//<script src='/Core/Security.js'></script>

/* export is used for js modules (when importing from other files) */
export default function UAD() {

    /* useState automatically creates a state variable (data), and its mutator (setData)
     * setData renders the page on state change */
    //const [data, setData] = useState(["Loading..."]);
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
    const loginCount = [{
        "2020-05-05": 2,
        "2020-05-06": 1,
        "2020-05-07": 0,
        "2020-05-08": 4
    }];
    const registerCount = [0, 1, 0, 2, 0, 5, 1];
    const reviewCount = [0, 1, 0, 2, 0, 5, 1];
    const newsCount = [0, 1, 0, 2, 0, 5, 1];
    const mostViewCount = [0, 1, 0, 2, 0, 5, 1];
    const durationViewCount = [0, 1, 0, 2, 0, 5, 1];

    return (
        <div className="uad-container">
            <Navigation />
            <h1>Usage Analysis Dashboard (UAD)</h1>
            <div>
                <TrendGraph title={"Number of Logins per day (last 3 months)"} dataList={loginCount} />
                <TrendGraph title={"Number of Registrations per day (last 3 months)"} dataList={loginCount} />
                <TrendGraph title={"Number of Reviews Created per day (last 3 months)"} dataList={loginCount} />
                <TrendGraph title={"Number of News Articles Created per day (last 3 months)"} dataList={loginCount} />
                <BarGraph title={"Top 5 Most Visited Views"} dataList={loginCount} />
                <BarGraph title={"Top 5 Views Based on Duration"} dataList={loginCount} />

            </div>
        </div>
    );
}