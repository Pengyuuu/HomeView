// React imports
import React, { useState, useEffect } from 'react';

// Custom and styling
import Navigation from '../../Navigation';
import ArticleThumb from './ArticleThumb.js'
import './../../../css/news.css';
import LogAccess from '../../Core/LogAccess';


/* export is used for js modules (when importing from other files) */
const News = () => {
    const NEWS_VIEW_ID = 7;
    LogAccess(NEWS_VIEW_ID);
    /* useState automatically creates a state variable (data), and its mutator (setData)
     * setData renders the page on state change */
    const [data, setData] = useState(["Loading..."]);

    useEffect(() => {
        let axios = require('axios');

        let config = {
            method: 'get',
            url: 'http://54.219.16.154/api/news',
            headers: {}
        };

        axios(config)
            .then(function (response) {
                setData(response.data);
            })
            .catch(function (error) {
                console.log(error);
            });

    }, []);
    /* useEffect is executed every time a state inside [] is changed (ie [data])
     * leave blank [] to only execute once and prevent calling API every state change*/

    /* length check to ensure it doesn't try generating initial "Loading..." val */
    console.log(data);
    return (
        <div className="news-container">
            <Navigation />
            <h1>HomeView News</h1>
            <div className="article-cluster">
                {data.length > 1 && data.map((article) => (
                    <ArticleThumb key={article.ArticleId} id={article.ArticleId} title={article.ArticleTitle} content={article.ArticleContent} />))
                }
            </div>
        </div>
    );
}



export default News;