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
    //const API_URL = `${process.env.REACT_APP_WEB_API}`.get(API_URL + `/uad`)
    /* useState automatically creates a state variable (data), and its mutator (setData)
     * setData renders the page on state change */
    const [loginCount, setloginCount] = useState([]);
    const [regCount, setReg] = useState([]);
    const [revCount, setRev] = useState([]);
    const [newsCount, setNews] = useState([]);
    const [topView, setTopView] = useState([]);
    const [durationCount, setDuration] = useState([]);

    useEffect(() => {
        let axios = require('axios');

        let config = {
            method: 'get',
            url: 'https://localhost:7034/api/uad',
            headers: {}
        };

        axios(config)
            .then(function (response) {
                setloginCount(response.data.loginCount);
                setReg(response.data.registrationCount);
                setRev(response.data.reviewCount);
                setNews(response.data.newsCount);
                setTopView(response.data.topViewCount);
                setDuration(response.data.durationViewCount);
            })
            .catch(function (error) {
                console.log(error);
            });

    }, []);

    return (
        <div className="uad-container">
            <Navigation />
            <h1>Usage Analysis Dashboard (UAD)</h1>
            <div>
                <TrendGraph title={"Number of Logins per day (last 3 months)"} dataList={loginCount} />
                <TrendGraph title={"Number of Registrations per day (last 3 months)"} dataList={regCount} />
                <TrendGraph title={"Number of Reviews Created per day (last 3 months)"} dataList={revCount} />
                <TrendGraph title={"Number of News Articles Created per day (last 3 months)"} dataList={newsCount} />
                <BarGraph title={"Top 5 Most Visited Views"} dataList={topView} />
                <BarGraph title={"Top 5 Views Based on Duration"} dataList={durationCount} />

            </div>
        </div>
    );
}