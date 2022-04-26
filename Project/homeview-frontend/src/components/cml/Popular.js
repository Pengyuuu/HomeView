import axios from 'axios';
import React, { useEffect, useState } from 'react';
import Requests from '../Requests';
import PopularMovieTile from './PopularMovieTile';
import PopularSeriesTile from './PopularSeriesTile.js';

function Popular() {

    const [ movies, setMovies ] = useState([]);
    const [ series, setSeries ] = useState([]);

    useEffect(() => {
        axios.request(Requests.fetchMoviePopular).then(function (response) {
            console.log(response.data);
            setMovies(response.data.results);
        }).catch(function (error) {
            console.error(error);
        });

        axios.request(Requests.fetchSeriesPopular).then(function (response) {
            console.log(response.data);
            setSeries(response.data.results);
        }).catch(function (error) {
            console.error(error);
        });


    }, []);
    
    return (
        <div>
            <span>
                Popular Movies
                <div className='movie-container'>
                    {movies.length > 0 && movies.map((movie) =>(
                        <PopularMovieTile key={movie.id} {...movie} />            
                    ))}
                </div>
            </span>
            <span>
                Popular Series
                <div className='series-container'>
                    {series.length > 0 && series.map((serie) =>(
                        <PopularSeriesTile key={serie.id} {...serie} />            
                    ))}
                </div>
            </span>
        </div>
    );
}
export default Popular;