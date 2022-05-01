// react imports
import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
// custom components
import Navigation from '../../Navigation';
// styling
import './../../../css/news.css';


//<script src='/Core/Security.js'></script>

/* ArticlePage comp works by adding a new page to the router in App.js
 * /news/article/id, where id is the id of the article
 * This component displays the entire Article*/
const Article = ({ title, content, image }) => {
    let { id } = useParams();

    const [data, setData] = useState(["Loading..."]);

    useEffect(() => {
        let axios = require('axios');

        let config = {
            method: 'get',
            url: 'http://54.219.16.154/api/news/' + id,
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

    console.log(data);
    return (
        <div className="article-container">
            <Navigation />
            <h1>HomeView Article</h1>
            <h2> {data.ArticleTitle} </h2>
            <p> {data.ArticleContent}</p>
        </div>
    );
}

export default Article
