import React from "react"
import './../../css/popularseriestile.css';

const IMG_API = "https://image.tmdb.org/t/p/original/"

const PopularSeriesTile = ({name, poster_path, overview, first_air_date, genre_ids, vote_average}) => {
    return (
        <>
        <div className='p-series'>
            <img src={IMG_API + poster_path} alt={name} />
            <div className='img-overlay img-overlay--blur'>
                <div className="series-title">{name}</div>
                <p className='overview'>{overview}</p>
            </div>
        </div>
        </>
    )
}

export default PopularSeriesTile