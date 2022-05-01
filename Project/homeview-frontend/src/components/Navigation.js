import React,{Component} from 'react'
import{NavLink} from 'react-router-dom'
import{Navbar, Nav} from 'react-bootstrap'
import './../css/navigation.css';

export class Navigation extends Component {
  render() {
      return (
        <div className="navigation">
            <Navbar bg="dark" expand="lg">
                <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                    <Navbar.Collapse id="basic-navbar-nav">
                        <Nav>
                            <NavLink className = "d-inline p-2 bg-dark text-white" to="/">
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
                    <NavLink className="d-inline p-2 bg-dark text-white ml-auto" to="/login">
                        Log Out
                    </NavLink>
            </Navbar>
        </div>
    )
  } 
}
export default Navigation

