import React from "react"
import  Register  from "./Core/Register"
import {Container} from 'react-bootstrap'
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom'
import  Home  from './Features/Home'
import  Login  from './Core/Login'
import { TVShows } from "./Features/TVShows"
import { Movies } from "./Features/Movies"
import { News } from "./Features/News"
import { ActWiki } from "./Features/ActWiki"
import  Title  from './Features/Title'

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