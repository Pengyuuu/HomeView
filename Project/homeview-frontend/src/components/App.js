import React from "react"
import { BrowserRouter as Router, Routes, Route, BrowserRouter } from 'react-router-dom'
import Register from "./Core/Register"
import Home from './Features/Home'
import Login from './Core/Login'
import AccountRecovery from './Core/AccountRecovery'
import TVShows from "./Features/TVShows"
import Movies from "./Features/Movies"
import News from "./Features/News/News"
import Article from "./Features/News/Article"
import ActWiki from "./Features/ActWiki/ActWiki"
import UserAccount from "./Features/UserAccount"
import Title from './Features/RatingReview/Title'
import UAD from './Core/UAD/UAD'
import Terms from './Core/Terms'
import UserPrivacy from './Core/UserPrivacy'
import Playlist from './Features/Playlist/Playlist'


function App() {


    const user = sessionStorage.getItem("token");

    return (
        <div className="app">
            <BrowserRouter>
                <Routes>
                    <Route exact path="/" element={<Home />} />
                    <Route exact path="/register" element={<Register />} />
                    <Route exact path="/login" element={<Login />} />
                    <Route exact path="/account-recovery" element={<AccountRecovery />} />
                    <Route exact path="/tvshows" element={<TVShows />} />
                    <Route exact path="/movies" element={<Movies />} />
                    <Route exact path="/news" element={<News />} />
                    <Route exact path="/news/article/:id" element={<Article />} />
                    <Route exact path="/useraccount" element={<UserAccount />} />
                    <Route exact path="/title" element={<Title />} />
                    <Route exact path="/uad" element={<UAD />} />
                    <Route exact path="/terms" element={<Terms />} />
                    <Route exact path="/user-privacy" element={<UserPrivacy />} />
                    <Route exact path="/playlist" element={<Playlist />} />
                </Routes>
            </BrowserRouter>
        </div>
    )
}

export default App;