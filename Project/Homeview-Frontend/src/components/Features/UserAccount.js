import React, { Component } from 'react'
import Navigation from '../Navigation'

//<script src='/Core/Security.js'></script>

export class UserAccount extends Component {
    render() {
        return (
            <div className="container">
                <h3 className="mt-5 d-flex justify-content-left">
                    This is where the UserAccount will be.
                </h3>
                <Navigation />

            </div>
        )
    }
}