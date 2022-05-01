import React from "react"
import {Container} from 'react-bootstrap'
import { BrowserRouter as Router, Routes, Route, BrowserRouter } from 'react-router-dom'

import Register from "./Core/Register"
import Home from './Features/Home'
import Login from './Core/Login'
import { TVShows } from "./Features/TVShows"
import { Movies } from "./Features/Movies"
import News from "./Features/News/News"
import Article from "./Features/News/Article"
import { ActWiki } from "./Features/ActWiki"
import { UserAccount } from "./Features/UserAccount"
import Title from './Features/TitlePage/Title'

function App() {

    return (
        <div className="app">
            <BrowserRouter>
                <Routes>
                    <Route exact path="/" element={<Home />} />
                    <Route exact path="/register" element={<Register />} />
                    <Route exact path="/login" element={<Login />} />
                    <Route exact path="/tvshows" element={<TVShows />} />
                    <Route exact path="/movies" element={<Movies />} />
                    <Route exact path="/news" element={<News />} />
                    <Route exact path="/news/article/:id" element={<Article />} />
                    <Route exact path="/actwiki" element={<ActWiki />} />
                    <Route exact path="/useraccount" element={<UserAccount />} />
                    <Route exact path="/title" element={<Title />} />
                </Routes>
            </BrowserRouter>
        </div>
    )
}

export default App;