import React from 'react'
import '../css/test.css'
import Navigation from './Navigation'
import FirstTimeUser from './FirstTimeUser'
import Library from './Library'


export default function Home() {
    //<script src='/Security.js'></script>

    const isFirst = checkFirstTimeUser()
    if (isFirst) {
        return (
            <>
                <Navigation/>
                <div className='logo'>
                    TESTING
                </div>
                <FirstTimeUser></FirstTimeUser>)

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
                <Library/>
            </>

        )
    }
    
}

function checkFirstTimeUser() {
    return false;
}


