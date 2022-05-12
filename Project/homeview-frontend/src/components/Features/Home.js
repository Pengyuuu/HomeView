import React from 'react'
import Navigation from '../Navigation'
import FirstTimeUser from './FirstTimeUser'
import Popular from '../cml/Popular'

export default function Home() {

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


