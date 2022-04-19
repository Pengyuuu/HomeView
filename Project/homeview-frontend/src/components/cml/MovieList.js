import React, {useEffect, useState} from 'react';
import axios from 'axios';
import Movie from './MovieTile';
import './../../css/movietile.css';
import TitleModal from '../../components/Features/TitlePage/TitleModal'


    const MOVIES_API = {
        method: 'GET',
        url: 'https://streaming-availability.p.rapidapi.com/search/basic',
        params: {
            country: 'us',
            service: 'netflix',
            type: 'movie',
            output_language: 'en',
            page: 40
        },
        headers: {
            'X-RapidAPI-Host': 'streaming-availability.p.rapidapi.com',
            'X-RapidAPI-Key': 'cc4a9a7618msh29ea64bd110ca53p17eeefjsncd4c7af4a976'
        }
    };

    const GENRE_API = {
        method: 'GET',
        url: 'https://streaming-availability.p.rapidapi.com/genres',
        headers: {
          'X-RapidAPI-Host': 'streaming-availability.p.rapidapi.com',
          'X-RapidAPI-Key': 'cc4a9a7618msh29ea64bd110ca53p17eeefjsncd4c7af4a976'
        }
      };   

    function MovieList() {
        const [ movies, setMovies ] = useState([]);
        const [modalShow, setModalShow] = useState(null);
        

        useEffect(() => {
            axios.request(MOVIES_API).then(function (response) {
                console.log(response.data);
                setMovies(response.data.results);
            }).catch(function (error) {
                console.error(error);
            });
        }, []);

        const handleState = (e) => {
            if (modalShow != null) {
                setModalShow(null);
            }
            else {
                setModalShow(e.target.key);
            }
        };
        const checkState = (e) => {
            if (e.target.key === modalShow) {
                return true;
            }
            else {
                return false;
            }
        }

        return (
            <div className='movie-container'>
                {movies.length > 0 && movies.map((movie) =>(
                    <Movie key={movie.tmdbID} {...movie} onClick={handleState} />,    
                    <TitleModal key={movie.tmdbID} {...movie} show={checkState} onHide={() => setModalShow(null)}/>        
                ))}
            </div>
        );
    }


export default MovieList