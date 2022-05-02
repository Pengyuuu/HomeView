import axios from 'axios';
import React,{useState,useEffect} from 'react'
import { useParams } from 'react-router-dom';
import Navigation from '../../Navigation'

//<script src='/Core/Security.js'></script>

const ActWiki = ({}) =>
{
        let {actName} = useParams;
        const [actDetails, setActDeatails] = useState([]);

        useEffect( () => {
            let axios = require("axios");
            let config = {
                method: 'get',
                url:`https://api.themoviedb.org/3/search/person?api_key=
                82da0caf88a6e84985e9fe3d753d6f43&language=en-US
                &query=`+ actName + `&page=1&include_adult=false`,
                headers:{}

            };

            axios(config)
            .then(function(res) {
                setActDeatails(res.data);
            })
        }, []);

        console.log(actDetails);
        return (
            <div className = "container">
                <Navigation/>
            </div>

        )
      /*
      .then(function (actObj) {
          var actInfo = actObj;
          return fetch(`https://api.themoviedb.org/3/person/${actInfo.id}?  
          api_key=${process.env.REACT_APP_TMDB_API_KEY}&language=en-US`)
          .then(function(result){
              return result.json();
          })
      })
      */
   
}
export default ActWiki



    