import React from "react"
import './../../css/movietile.css';

const IMG_API = "https://image.tmdb.org/t/p/original/"

const PopularMovieTile = ({title, poster_path, overview, release_date, genre_ids, vote_average}) => {
    return (
        <>
        <div className='movie'>
            <img src={IMG_API + poster_path} alt={title} />
            <div className='img-overlay img-overlay--blur'>
                <div className="movie-title">{title}</div>
                <p className='overview'>{overview}</p>
            </div>
        </div>
        </>
    )
}

export default PopularMovieTile