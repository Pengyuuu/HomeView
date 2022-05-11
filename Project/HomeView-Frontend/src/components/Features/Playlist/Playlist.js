import React, {useState, useEffect} from 'react'
import Navigation from '../../Navigation'
import PlaylistList from './PlaylistList';
import axios from 'axios';

export default function Playlist() {
    
  const [data, setData] = useState([]);

  useEffect(() => {

    //const email = "may@gmail.com";
    const email = "may@gmail.com"
    /*
    const PLAYLIST_API_GET = `${process.env.REACT_APP_WEB_API}`;
    */
    const PLAYLIST_API_GET = {
        method: 'get',
        url: `http://54.219.16.154/get/playlist/${email}`,
        headers: { }
    };

    axios.request(PLAYLIST_API_GET).then(function (response) {
        setData(response.data);
    }).catch(function (error) {
        console.error(error);
    });
  }, []);

  return(
    <div>
      <Navigation/>
      <div className='background-Homeview'></div>
      {data.length > 0 && data.map((playlist) => (
        <PlaylistList playlist={playlist} />
      ))}
    </div>
  )
}