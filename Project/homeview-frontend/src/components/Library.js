import React from 'react'
import '../css/test.css'
import Navigation from './Navigation'

export default function Library() {
    //<script src='/Security.js'></script>

    const userPref = getUserPref()
    if (userPref) {
        return (
            <>
                <Navigation>
                </Navigation>
                <div className='logo'>
                    TEST

                </div>

            </>

        )
    }
    else {
        return (
            <>
                <Navigation>
                </Navigation>
                <div className='logo'>
                    TEST
                </div>
            </>

        )
    }

}

// genre list and services list
function getUserPref() {
    return false
}


