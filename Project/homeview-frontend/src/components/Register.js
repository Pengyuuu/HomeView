import React, {useRef} from 'react'
import {Form, Button, Card} from 'react-bootstrap'
import {Link} from 'react-router-dom'

export default function Register() {
    const emailRef = useRef()
    const passwordRef = useRef()
    const birthdayRef = useRef()

  return (
      <>
      <div className='background-Homeview'>
         <div className='card-center'>
            <Card>
                <Card.Body>
                <h2 className="text-center mb-4"> Sign Up</h2>
          
                <Form>
                    <Form.Group id="email">
                        <Form.Label>Email</Form.Label>
                        <Form.Control type="email" ref = {emailRef} required></Form.Control>
                    </Form.Group>
                    <Form.Group id="password">
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" ref = {passwordRef} required></Form.Control>
                    </Form.Group>
                    <Form.Group id="birthday">
                        <Form.Label>Birthday</Form.Label>
                        <Form.Control type="date" ref = {birthdayRef} required></Form.Control>
                              </Form.Group>
                              <br></br>
                              <Button className="w-100" type="submit" onclick={register()}>
                    Sign Up
                    </Button>
                </Form>
                </Card.Body>
            </Card>
            <div className="w-100 text-center mt-2 extraInfo">
            Already have an account? <Link to ="/login">Log In</Link>
            </div>
          </div>
      </div>
    </>
  )
}

function register() {
    // call c# backend

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
}
