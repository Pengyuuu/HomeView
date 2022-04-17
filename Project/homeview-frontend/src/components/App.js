import React from "react"
import Register from "./Register"
import {Container} from 'react-bootstrap'
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom'
import Home from './Home'
import Login from './Login'
import { TVShows } from "./TVShows"
import { Movies } from "./Movies"
import { News } from "./News"
import { ActWiki } from "./ActWiki"
import Title  from './Title'

function App() {

    return (
        <Container className="d-flex align-items-center
            justify-content-center"
            style={{minHeight:"100vh"}}>
            <div className="w-100" style={{ maxWidth: "400px" }}>
                <Router>
                    <Routes>
                        <Route exact path="/" element={<Home />} />
                        <Route exact path="/register" element={<Register />} />
                        <Route exact path="/login" element={<Login />} />
                        <Route exact path="/tvshows" element={<TVShows />} />
                        <Route exact path="/movies" element={<Movies />} />
                        <Route exact path="/news" element={<News />} />
                        <Route exact path="/actwiki" element={<ActWiki />} />
                        <Route exact path="/title" element={<Title />} />
                    </Routes>
                </Router>
            </div>
        </Container>
    )
}

export default App;