import React, {useRef} from 'react'
import {Form, Button, Card} from 'react-bootstrap'
import {Link} from 'react-router-dom'


export default function Register() {

    const emailRef = useRef()
    const passwordRef = useRef()
    const birthdayRef = useRef()

    return (
            <div>
            <div className='background-Homeview'></div>
                <div className='card-center'>
                    <Card>
                        <Card.Body>
                            <h2 className="text-center mb-4"> Sign Up</h2>
                            <Form onSubmit={registerUser}>
                                <Form.Group id="email">
                                    <Form.Label>Email</Form.Label>
                                    <Form.Control name = 'Email' type="email" ref={emailRef} required placeholder="Email" ></Form.Control>
                                </Form.Group>
                                <Form.Group id="password">
                                    <Form.Label>Password</Form.Label>
                                    <Form.Control name = 'Password' type="password" ref={passwordRef} required placeholder="Password" ></Form.Control>
                                </Form.Group>
                                <Form.Group id="birthday">
                                    <Form.Label>Birthday</Form.Label>
                                    <Form.Control name = 'Birthday' type="date" ref={birthdayRef} required placeholder="Birthday" ></Form.Control>
                                </Form.Group>
                                <br></br>
                                <Button type="submit" className="btn-signup">
                                    Sign Up
                                </Button>
                            </Form >
                            
                        </Card.Body>
                    </Card>
                    <div className="w-100 text-center mt-2 extraInfo">
                        Already have an account? <Link to="/login">Log In</Link>
                    </div>
                </div>
            </div>
    )

    async function registerUser() {
        console.log('start reg')
        
        fetch('https://reqres.in/api/users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name: 'hardname',
                job: 'hardjob'
            })
        }).then (res=> {
                return res.json()
            })
            .then (data=> console.log(data))

        console.log('end reg')
    }
}
    // call c# backend
    /*
    Validate info server side
    Validate info client side

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

    $.ajax({
        type: "POST",
        url: 'Default.aspx/DeleteItem',
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $("#divResult").html("success");
        },
        error: function (e) {
            $("#divResult").html("Something Wrong.");
        }
    });
    */
