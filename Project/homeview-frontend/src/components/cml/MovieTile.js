import React, { useState } from 'react';
import TitleModal from '../Features/TitlePage/TitleModal';
import './../../css/movietile.css';


const IMG_API = "https://image.tmdb.org/t/p/original/"

const Movie = ({ title, posterPath, overview }) => {
    const [modalShow, setModalShow] = useState(false);
    console.log(title, posterPath, overview);
    return[
    
        <div className='movie' onClick={() => setModalShow(true)}>
            <img src={IMG_API + posterPath} alt={title} />
            <div className='img-overlay img-overlay--blur'>
                <div className="movie-title">{title}</div>
                <p className='overview'>{overview}</p>
            </div>
            <TitleModal title={title} poster={posterPath} overview={overview} show={modalShow} onHide={() => setModalShow(false)}
            />
        </div>
    ]
}


export default Movie;