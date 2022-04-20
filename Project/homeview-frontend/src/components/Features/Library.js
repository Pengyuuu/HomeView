import React from 'react'
import Navigation from '../Navigation'
<script src='/Core/Security.js'></script>

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


