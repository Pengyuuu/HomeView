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



    const BLACKLIST_API_GET = {
        method: 'get',
        url: 'http://54.219.16.154/api/blacklist/?selectedUser=HankHill@yahoo.com',
        headers: { }
    };

    // if blacklist toggle is true, render this
    function MovieList({service}) {
        const [ movies, setMovies ] = useState([]);
        const [items, setItems] = useState([])

        const blacklist = []
        const bItems = []

        let offset = 1;

        const loadMoreMovies = () => {
            axios.get(`https://streaming-availability.p.rapidapi.com/search/basic?country=us&service=${service}&type=series&language=en&page=${offset}`,
             {headers: {'X-RapidAPI-Key': 'cc4a9a7618msh29ea64bd110ca53p17eeefjsncd4c7af4a976'}})
             .then(function (response) {
                console.log(response.data.results);
                setMovies(oldMovies => [...oldMovies, ...response.data.results]);
            }).catch(function (error) {
                console.error(error);
            });
            offset += 1;
        }

        const handleScroll=(e)=> {
            if (window.innerHeight + e.target.documentElement.scrollTop + 1 >= e.target.documentElement.scrollHeight) {
                loadMoreMovies();
            }
        }

        useEffect(() => {
        
            axios.request(BLACKLIST_API_GET).then(function (response) {
                console.log(response.data);
                setItems(response.data);
            }).catch(function (error) {
                console.error(error);
            });

            loadMoreMovies();
            window.addEventListener('scroll', handleScroll)

        }, []);
        /**
         * items = blackist data fetched, list of blacklists containing dispName, blacklistItem, toggle
         * for each item in items, get item's blacklistItem and push to bItem arr
         */
        items.forEach((item) => (
            bItems.push(item.blacklistItem)
        ))
        console.log(bItems)
       // const test = ["Ed Helms", 35, "test"]
       /**
        * Loop for each movie in movies
        * Loop for each cast member in cast
        * if bItems contains a cast member from movie
        * add to blacklist array
        */
        movies.forEach((movie) => (
            movie.cast.forEach((cast) => 
                //console.log(test.includes(cast)))
                {if (bItems.includes(cast)) {
                    blacklist.push(movie)
                    console.log(movie)
                }}
            )       
        ))  
        
        /**
        * Loop for each movie in movies
        * Loop for each genre in genres
        * if bItems contains a genre from genre
        * check if its already in blacklist
        * add to blacklist array
        */
        movies.forEach((movie) => (
            movie.genres.forEach((genre) => 
                //console.log(test.includes(genre)))
                {if (bItems.includes(genre.toString())) {
                    if (!blacklist.includes(movie)) {
                        blacklist.push(movie)
                        console.log(movie)
                    }
                }}
            )       
        ))  
        //console.log(blacklist)
        /**
         * checks every element in movie w/ every element in blacklist
         * and filters out any matching elements
         * so finalList should only have elements not in blacklist arr
         */      
        const finalList = movies.filter(element => ! blacklist.includes(element));
        //console.log(finalList)
        
        // use effect clears state, was getting memory leak before
        useEffect(() => {
            return () => {
                {setMovies({})}
                {setItems({})}
            };
        },[])
        return (
            <div className='movie-container'>
                {finalList.length > 0 && finalList.map((movie) => (
                    <MovieTile key={movie.tmdbID} {...movie} />            
                ))}
                
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