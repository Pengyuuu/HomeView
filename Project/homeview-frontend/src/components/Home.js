import React from 'react'
import '../css/test.css'
import Navigation from './Navigation'
import FirstTimeUser from './FirstTimeUser'

export default function Home() {

  //const userFirstTime = {}
    return (
      <>
      <Navigation>
      </Navigation>
      <div className='logo'>
        TEST
      </div>
      <FirstTimeUser></FirstTimeUser>
      </>
  )
}
