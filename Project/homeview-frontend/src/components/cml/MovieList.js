import React, {useEffect, useState} from 'react';
import axios from 'axios';
import MovieTile from './MovieTile';
import { Card } from 'react-bootstrap'

//import './../../css/movietile.css';
import MovieListBlacklistTrue from '../Features/Blacklist/MovieListBlacklistTrue'
import MovieListBlacklistFalse from '../Features/Blacklist/MovieListBlacklistFalse'

const BLACKLIST_API_GET_TOGGLE = {
    method: 'get',
    url: 'http://54.219.16.154/api/blacklist/toggle?selectedUser=may@yahoo.com',
    headers: { }
};

const COUNTRIES_API = {
    method: 'GET',
    url: 'https://streaming-availability.p.rapidapi.com/countries',
    headers: {
        'X-RapidAPI-Host': 'streaming-availability.p.rapidapi.com',
        'X-RapidAPI-Key': 'cc4a9a7618msh29ea64bd110ca53p17eeefjsncd4c7af4a976'
    }
}; 

    function MovieList() {
        const [toggle, setToggle] = useState();
        const [ streamService, setStreamService ] = useState([]); 
        const [value, setValue] = useState();

        // web api call get toggle
        useEffect(() => {
            axios.request(BLACKLIST_API_GET_TOGGLE).then(function (response) {
                //console.log(response.data.blacklistToggle);
                setToggle(response.data.blacklistToggle);
            }).catch(function (error) {
                console.error(error);
            });

            axios.request(COUNTRIES_API).then(function (response) {
                setStreamService(response.data);
            }).catch(function (error) {
                console.error(error);   
            });


            if (window.localStorage.getItem('state') == null) {
                window.localStorage.setItem('state', 'netflix')
                setValue('netflix')
            }
            else {
                setValue(window.localStorage.getItem('state'))
            }

        }, []);

        const handleChange = (event) => {
           window.localStorage.setItem('state', event.target.value)
           window.location.reload();
        }

        

        // if true return blacklist view
        // else return regular view (all movies)
        if (toggle) {

            return (
            <>
            <div className ="container p-5">
            <label>
                Select a Streaming Service
                <select value={value} onChange={handleChange}>
                {Object.keys(streamService).map((option) => (
                    <option key={option} value={streamService.value}>{option}</option>))}
                </select>
            </label>
            </div>       
            <MovieListBlacklistTrue service = {value} />
            </>)
            
        }
        else {
            return (
                <>
                <div className ="container p-5">
                    <label>
                        Select a Streaming Service
                        <select value={value} onChange={handleChange}>
                        {Object.keys(streamService).map((option) => (
                            <option key={option} value={streamService.value}>{option}</option>))}
                        </select>
                    </label>

                    <p></p>
                </div>    

                <MovieListBlacklistFalse/>
                </>
            ) 
        }
            
    }

export default MovieList