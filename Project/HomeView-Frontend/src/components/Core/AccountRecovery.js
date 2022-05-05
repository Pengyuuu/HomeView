import React from 'react'
import {Form, Button, Card} from 'react-bootstrap'
import { Link } from 'react-router-dom'
import '../../css/App.css'
import axios from 'axios';


export default function AccountRecovery() {

    return (
        <div>
        <div className='background-Homeview'></div>
            <div className='card-center'>
                <Card>
                    <Card.Body>
                        <h2 className="text-center mb-4"> Account Recovery</h2>
                        <Form id='form' onSubmit={verifyUser}>
                            <Form.Group id="email">
                                <Form.Label>Email</Form.Label>
                                <Form.Control name='Email' type="email" required id='email'></Form.Control>
                            </Form.Group>
                            <Form.Group id="username">
                                <Form.Label>Username</Form.Label>
                                <Form.Control name='Username' required id='username'></Form.Control>
                            </Form.Group>
                            <br></br>
                            <Button className="w-100" type="submit" id="btn-login">
                                Recover Account
                            </Button>
                        </Form>
                    </Card.Body>
                </Card>
                <div className="w-100 text-center mt-2 extraInfo">
                    Need an account? <Link to="/register">Sign Up</Link>
                </div>
                <div className="w-100 text-center mt-2 extraInfo">
                    Have an Account? <Link to="/login">Log In</Link>
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
    e.preventDefault();
    let email = e.target.Email.value;
    let username = e.target.Username.value;

    var data = {
        email: email,
        username: username
    }

    const accountRecoverURL = 'http://54.219.16.154/api/account/recover/' + email +'/' + username
    
    fetch(accountRecoverURL, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(res => {
        console.log(res)
            return res.json()
        })
        .then (data=> console.log("reach"))


    /**
    axios.request(accountRecoverURL).then(function (response) {
        console.log(response.data);
    }).catch(function (error) {
        console.error(error);
    });  ** /

    console.log('end login')
    //loginUser(email)
}

// Call backend to get token from server -> should GetJWTToken method from login controller
function loginUser(email) {
    var data = {
        email: email,
    }
    console.log('getting token', email);
    // api route:  /api/login/get/token/{email}
    fetch('https://reqres.in/api/users', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            data
        })
    }).then(res => {
        return res.json()
    })
        .then(data => console.log(data))

    // temp test token
    window.sessionStorage.setItem('token', data)


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
