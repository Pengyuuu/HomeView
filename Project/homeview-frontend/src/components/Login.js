import React from 'react'
import {Form, Button, Card} from 'react-bootstrap'
import { Link } from 'react-router-dom'
import '../css/App.css'

export default function Login() {

    return (
        <div>
        <div className='background-Homeview'></div>
            <div className='card-center'>
                <Card>
                    <Card.Body>
                        <h2 className="text-center mb-4"> Log In</h2>
                        <Form id='form' onSubmit={verifyUser}>
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
            </div>
        </div>
    )
}

/*
Get email and pass and verify w/ backend and send back a jwt token
Store token in sessionStorage


*/

function verifyUser(e) {

    let email = e.target.Email.value;
    let password = e.target.Password.value;

    var data = {
        email: email,
        password: password
    }
    
    console.log('start login')
    
    fetch('https://reqres.in/api/users', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            data
        })
    }).then (res=> {
            return res.json()
        })
        .then (data=> console.log(data))

    console.log('end login')
    loginUser(email)
}

// Call backend to get token from server
function loginUser(email) {

    console.log('logging in', email);

    // temp test token
    window.sessionStorage.setItem('token', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c')


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

    const token = window.sessionStorage.setItem("token", )
    */

    
}
