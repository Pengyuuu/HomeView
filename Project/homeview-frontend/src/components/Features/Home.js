import React from 'react'
import Navigation from '../Navigation'
import FirstTimeUser from './FirstTimeUser'
import Library from './Library'
import Movie from '../cml/MovieList'
import Popular from '../cml/Popular'


//<script src='/Core/Security.js'></script>

export default function Home() {
    //<script src='/Security.js'></script>

    // to fill our first time form
    const isFirst = checkFirstTimeUser()
    if (isFirst) {
        return (
            <>
                <Navigation/>
                <div className='logo'>
                    Your HomeViews
                </div>
                <FirstTimeUser></FirstTimeUser>

            </>
        )
    }
    else {
        return (
            <>
                <Navigation />
                <div className='logo'>
                    Your HomeViews
                </div>
                
                <Popular/>
            </>

        )
    }
    
}

function checkFirstTimeUser() {
    return false;
}


