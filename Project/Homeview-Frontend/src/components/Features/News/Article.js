// react imports
import React from 'react';
import { useParams } from 'react-router-dom';
// custom components
import Navigation from '../../Navigation';
// styling
import './../../../css/news.css';


//<script src='/Core/Security.js'></script>

/* ArticlePage comp works by adding a new page to the router in App.js
 * /news/article/id, where id is the id of the article
 * This component displays the entire Article*/
const ArticlePage = ({ title, content, image }) => {
    let { id } = useParams();

    return (
        <div className="articlepage-container">
            <Navigation />
            <h1>HomeView Article</h1>
            <h1> {title} </h1>
            <p> {content}</p>
            <h2> {id} </h2>
        </div>
    );
}

export default ArticlePage
