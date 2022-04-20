import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { Button } from 'react-bootstrap';
import clearToken from '/Security.js';

function Navbar() {
    return (
        <>
            <nav className='navBar'>
                <div className='navbar-container'>
                    <Link className="color-style" to="/">Home</Link> <span></span>
                    <Link className="color-style" to="/">TV Shows</Link> <span></span>
                    <Link className="color-style" to="/">Movies</Link> <span></span>
                    <Link className="color-style" to="/">News</Link> <span></span>
                    <Link className="color-style" to="/">ActWiki</Link> <span></span>
                    <Link className="color-style" to="/">Account</Link> <span></span>
                    <Button className="color-style" type="submit" onclick={clearToken}>Log Out </Button>


                </div>
            </nav>
        </>
    );
}

export default Navbar;