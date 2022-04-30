import React from 'react';
import { Link } from 'react-router-dom';
import './../../../css/news.css';

import Article from "./Article"
//<script src='/Core/Security.js'></script>

/* Article comp takes data from News comp passed through attributes 
 * Uses 'deconstruction' to get params from props (?) 
 * This component is only a thumbnail of the main article */
const ArticleThumb = ({ id, title, content, image }) => {

    const handleClick = () => {
        let artPath = "/news/article/" + id;
        window.location.href = artPath;
    };

    return (
        <div className="article-container" onClick={handleClick}>
            <h1> {title} </h1>
            <p> {content}</p>
        </div>
    );

}

export default ArticleThumb
