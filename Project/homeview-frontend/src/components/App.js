import React from "react"
import Register from "./Register"
import {Container} from 'react-bootstrap'
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom'
import Home from './Home'
import Login from './Login'

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
                    </Routes>
                </Router>
            </div>
        </Container>
    )
}

export default App;