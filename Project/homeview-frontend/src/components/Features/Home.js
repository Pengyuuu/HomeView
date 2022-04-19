import React from 'react'
import Navigation from '../Navigation'
import FirstTimeUser from './FirstTimeUser'
import Movie from '../cml/MovieList'

export default function Home() {
    //<script src='/Security.js'></script>
    //const [titleClick, setTitle] = useState(false);
    /*
    var listofShows = [];
    let props = {
        title: "Power Rangers",
        year: 2001,
        imgsrc: "https://i.pinimg.com/originals/e8/6e/a3/e86ea309f7be09e85d38bb38e40690da.jpg",
        rating: 4.5,
        hvRating: "PG-13",
        services: ["Netflix", "Hulu"],
        genres: ["action", "kids"],
        actors: ["tommy oliver"]
    };

    let props2 = {
        title: "Breaking Bad",
        year: 2011,
        imgsrc: "https://m.media-amazon.com/images/I/51fWOBx3agL._AC_.jpg",
        rating: 3,
        hvRating: "PG-13",
        services: ["Netflix"],
        genres: ["action"],
        actors: ["breaking bad actors"]
    };
    listofShows.push(props);
    listofShows.push(props2);
    */



    const isFirst = checkFirstTimeUser()
    if (isFirst) {
        return (
            <>
                <Navigation/>
                <div className='logo'>
                    TESTING
                </div>
                <FirstTimeUser></FirstTimeUser>

            </>
        )
    }
    else {
        return (
            <>
                <Navigation/>
                <div className='logo'>
                    Your HomeViews
                </div>
                <Movie/>
                
            </>

        )
    }
    
}

function checkFirstTimeUser() {
    return false;
}


