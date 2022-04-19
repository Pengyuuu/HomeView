import React from 'react';
import './../../css/movietile.css';

const IMG_API = "https://image.tmdb.org/t/p/original/"

const Movie = ({title, posterPath, overview}) => (

<div className='movie'>
        <img src={IMG_API + posterPath} alt={title}/>
        <div className='img-overlay img-overlay--blur'>
            <div className="movie-title">{title}</div>
            <p className='overview'>{overview}</p>
        </div>
    </div>
)

export default Movie;