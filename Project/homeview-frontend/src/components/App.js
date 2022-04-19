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

function App() {

    return (
        <Container className="app-container">
            <div className="w-100">
                <Router>
                    <Routes>
                        <Route exact path="/" element={<Home />} />
                        <Route exact path="/register" element={<Register />} />
                        <Route exact path="/login" element={<Login />} />
                        <Route exact path="/tvshows" element={<TVShows />} />
                        <Route exact path="/movies" element={<Movies />} />
                        <Route exact path="/news" element={<News />} />
                        <Route exact path="/actwiki" element={<ActWiki />} />
                    </Routes>
                </Router>
            </div>
        </Container>
    )
}

export default App;