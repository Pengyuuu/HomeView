import React, {useEffect, useState} from 'react';
import axios from 'axios';
import MovieTile from './MovieTile';
//import './../../css/movietile.css';
import MovieListBlacklistTrue from '../Features/Blacklist/MovieListBlacklistTrue'
import MovieListBlacklistFalse from '../Features/Blacklist/MovieListBlacklistFalse'

const BLACKLIST_API_GET_TOGGLE = {
    method: 'get',
    url: 'http://54.219.16.154/api/blacklist/toggle?selectedUser=HankHill@yahoo.com',
    headers: { }
};

    function MovieList() {
        const [toggle, setToggle] = useState();

        useEffect(() => {
            axios.request(BLACKLIST_API_GET_TOGGLE).then(function (response) {
                //console.log(response.data.blacklistToggle);
                setToggle(response.data.blacklistToggle);
            }).catch(function (error) {
                console.error(error);
            });
        }, []);

        if (toggle) {
            return <MovieListBlacklistTrue/>
        }
        else {
            return <MovieListBlacklistFalse/>
        }
            
    }

export default MovieList