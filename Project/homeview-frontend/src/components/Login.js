import React, {useRef} from 'react'
import {Form, Button, Card} from 'react-bootstrap'
import { Link } from 'react-router-dom'
import '../css/App.css'

export default function Login() {
    const emailRef = useRef()
    const passwordRef = useRef()

    return (
        <div>
        <div className='background-Homeview'></div>
            <div className='card-center'>
                <Card>
                    <Card.Body>
                        <h2 className="text-center mb-4"> Log In</h2>
                        <Form>
                            <Form.Group id="email">
                                <Form.Label>Email</Form.Label>
                                <Form.Control type="email" ref={emailRef} required></Form.Control>
                            </Form.Group>
                            <Form.Group id="password">
                                <Form.Label>Password</Form.Label>
                                <Form.Control type="password" ref={passwordRef} required></Form.Control>
                            </Form.Group>
                            <br></br>
                            <Button className="w-100" type="submit" onclick={loginUser()}>
                                Log In
                            </Button>
                        </Form>
                    </Card.Body>
                </Card>
                <div className="w-100 text-center mt-2 extraInfo">
                    Need an account? <Link to="/register">Sign Up</Link>
                </div>
            </div>
        </div>
    )
}


function loginUser() {
    // call backend
    /*
    var username = document.querySelector("input[type='username']").value;
    var password = document.querySelector("input[type='password']").value;

    var successMessage = document.getElementById("success");
    var errorMessage = document.getElementById("error");

    // Lecture:
    // Send user credentials to the server to validate

    if (username === "john" && password === "smith") {
        // Create the authentication cookie
        document.cookie = "username=john;path=/;samesite=strict;";


        errorMessage.style.visibility = 'hidden';
        successMessage.style.visibility = 'visible';

        alert("Login Success");

        return true;
    } else {

        successMessage.style.visibility = 'hidden';
        errorMessage.style.visibility = 'visible';

        return false;
    }
    */
}
