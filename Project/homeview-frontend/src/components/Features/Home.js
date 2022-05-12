import React from 'react'
import Navigation from '../Navigation'
import FirstTimeUser from './FirstTimeUser'
import Popular from '../cml/Popular'
import LogAccess from '../Core/LogAccess'


//<script src='/Core/Security.js'></script>

export default function Home() {

    const HOME_VIEW_ID = 2;
    LogAccess(HOME_VIEW_ID);
    // to fill our first time form
    const isFirst = checkFirstTimeUser()
    if (isFirst) {
        return (
            <>
                <Navigation />
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

                <Popular />
            </>

        )
    }

}

function checkFirstTimeUser() {
    return false;
}


