import React, {useState, useEffect} from 'react'
import Navigation from '../../Navigation'
import PlaylistList from './PlaylistList';
import axios from 'axios';
import { Button } from 'react-bootstrap';

export default function Playlist() {
    
  const [data, setData] = useState([]);

  const email = "may@gmail.com"

  useEffect(() => {

    //const email = "may@gmail.com";
    /*
    const PLAYLIST_API_GET = `${process.env.REACT_APP_WEB_API}`;
    */
    const PLAYLIST_API_GET = {
        method: 'get',
        url: `http://54.219.16.154/api/playlist/get/?email=${email}`,
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
      <Button>Create a Playlist</Button>
      {data.length > 0 && data.map((playlist) => (
        <PlaylistList playlist={playlist} />
      ))}
    </div>
  )
}