import React, { useEffect } from 'react'
import {Form, Button, Card} from 'react-bootstrap'
import { BrowserRouter, Link, useHistory, useNavigate } from 'react-router-dom'
import '../../css/App.css'
import axios from 'axios';
import { useBootstrapBreakpoints } from 'react-bootstrap/esm/ThemeProvider';
import Home from '.././Features/Home'
import AuthService from "./../../services/authentication"




export default function Login() {

    const navigate = useNavigate();

    const handleLogin = async (e) => {
        e.preventDefault();
        let email = e.target.Email.value;
        let password = e.target.Password.value;

        try {
            await AuthService.login(email, password).then (
                () => {
                    navigate("/");
                    window.location.reload();
                },
                (error) => {
                    console.log(error);
                }
            );
        }
        catch (err) {
            console.log(err);
        }
    };

    return (
        <div>
        <div className='background-Homeview'></div>
            <div className='card-center'>
                <Card>
                    <Card.Body>
                        <h2 className="text-center mb-4"> Log In</h2>
                        <Form id='form' onSubmit={handleLogin}>
                            <Form.Group id="email">
                                <Form.Label>Email</Form.Label>
                                <Form.Control name='Email' type="email" required id='email'></Form.Control>
                            </Form.Group>
                            <Form.Group id="password">
                                <Form.Label>Password</Form.Label>
                                <Form.Control name='Password' type="password"  required id='password'></Form.Control>
                            </Form.Group>
                            <br></br>
                            <Button className="w-100" type="submit" id="btn-login">
                                Log In
                            </Button>
                        </Form>
                    </Card.Body>
                </Card>
                <div className="w-100 text-center mt-2 extraInfo">
                    Need an account? <Link to="/register">Sign Up</Link>
                </div>
                <div className="w-100 text-center mt-2 extraInfo">
                    Forgot Password? <Link to="/account-recovery">Account Recovery</Link>
                </div>
            </div>
        </div>
    )
}


    

