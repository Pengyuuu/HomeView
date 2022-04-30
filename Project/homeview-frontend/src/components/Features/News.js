import React, { useState, useEffect } from 'react';
import Navigation from '../Navigation';
import './../../css/news.css';

//<script src='/Core/Security.js'></script>

/* export is used for js modules (when importing from other files) */
export const News = () => {

    /* useState automatically creates a state variable (data), and its mutator (setData)
     * setData renders the page on state change */
    const [data, setData] = useState("Loading...");

    useEffect(() => {
        var axios = require('axios');

        var config = {
            method: 'get',
            url: 'http://54.219.16.154/api/news/add2/',
            headers: {}
        };

        axios(config)
            .then(function (response) {
                setData(JSON.stringify(response.data));
            })
            .catch(function (error) {
                console.log(error);
            });
    }, []);
    /* useEffect is executed every time a state inside [] is changed (ie [data])
     * leave blank [] to only execute once and prevent calling API every state change*/

    return (
        <div className="news-container">
            <Navigation />
            <div className="article-cluster" />
        </div>

    );

}
