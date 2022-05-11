import React,{Component} from 'react'
import{NavLink} from 'react-router-dom'
import{Navbar, Nav} from 'react-bootstrap'
import './../css/navigation.css';
import AuthService from '../services/authentication';

function Navigation() {

    function clearToken() {
        console.log('clear tokens')
    
        sessionStorage.removeItem('token');
    }
      return (
        <div className="navigation">
            <Navbar bg="dark" expand="lg">
                <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                    <Navbar.Collapse id="basic-navbar-nav">
                        <Nav>
                            <NavLink className = "d-inline p-2 bg-dark text-white" to="/Home">
                                Home
                            </NavLink>
                            <NavLink className = "d-inline p-2 bg-dark text-white" to="/TVShows">
                                TV Shows
                            </NavLink>
                            <NavLink className = "d-inline p-2 bg-dark text-white" to="/Movies">
                                Movies
                            </NavLink>
                            <NavLink className = "d-inline p-2 bg-dark text-white" to="/News">
                                News
                            </NavLink>
                            <NavLink className = "d-inline p-2 bg-dark text-white" to="/ActWiki">
                                Act Wiki
                            </NavLink>
                        </Nav>
                        </Navbar.Collapse>
                        <NavLink className="d-inline p-2 bg-dark text-white ml-auto" to="/UserAccount">
                            Account
                        </NavLink>
                        <a href="/login" className="d-inline p-2 bg-dark text-white ml-autoe" onClick={AuthService.logout}>Logout</a> <span></span>


            </Navbar>
        </div>
    )
  } 

export default Navigation

