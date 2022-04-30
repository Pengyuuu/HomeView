import React from "react"
import './../../css/popularseriestile.css';

const IMG_API = "https://image.tmdb.org/t/p/original/"

const PopularSeriesTile = ({ name, poster_path, overview, first_air_date, genre_ids, vote_average }) => {
    var img = "../css/images/powerrng.jpg";

    if (poster_path != null) {
        img = IMG_API + poster_path
    }

    return (
        <div className='p-series'>
            <img src={img} alt={img} />
            <div className='img-overlay img-overlay--blur'>
                <div className="series-title">{name}</div>
                <p className='overview'>{overview}</p>
            </div>
        </div>
    )
}

export default PopularSeriesTile