import React, {useEffect, useState} from 'react';
import axios from 'axios';
import MovieTile from '../../cml/MovieTile';
import'./../../../css/movietile.css';

    const MOVIES_API = {
        method: 'GET',
        url: 'https://streaming-availability.p.rapidapi.com/search/basic',
        params: {
            country: 'us',
            service: 'netflix',
            type: 'series',
            output_language: 'en',
            language: 'en',
            page: 40
        },
        headers: {
            'X-RapidAPI-Host': 'streaming-availability.p.rapidapi.com',
            'X-RapidAPI-Key': 'cc4a9a7618msh29ea64bd110ca53p17eeefjsncd4c7af4a976'
        }
    }; 
    const GENRES_API = {
        method: 'GET',
        url: 'https://streaming-availability.p.rapidapi.com/genres',
        headers: {
          'X-RapidAPI-Host': 'streaming-availability.p.rapidapi.com',
          'X-RapidAPI-Key': 'cc4a9a7618msh29ea64bd110ca53p17eeefjsncd4c7af4a976'
        }
      };  

    // if blacklist toggle is false, render this (all movies)
    function MovieList() {
        const [ movies, setMovies ] = useState([]);


        useEffect(() => {
            
            axios.request(MOVIES_API).then(function (response) {
                console.log(response.data);
                console.log(response.data.results);
                setMovies(response.data.results);
            }).catch(function (error) {
                console.error(error);
            });
            
        }, []);

        // use effect clears state, was getting memory leak before
        return (
            <div className='movie-container'>
                {movies.length > 0 && movies.map((movie) => (
                    <MovieTile key={movie.tmdbID} {...movie} />            
                ))}
                {useEffect(() => {
                    return () => {
                        {setMovies({})}
                    };
                },[])}
            </div>
        );
    }

    function GenreList() {

        const [genres, setGenres] = useState();
        
        useEffect(() => {
            axios.request(GENRES_API)
            .then(function (response) {
                setGenres(response.data)
                
            })
            .catch(function (error) {
                console.error(error);
            });

        }, []);

        

    }




export default MovieList