import React, {useRef} from 'react'
import {Form, Button, Card} from 'react-bootstrap'
import {Link} from 'react-router-dom'


export default function Register() {

    const passwordRef = useRef();

    const [disable, setDisable] = React.useState(false);

    return (
            <div>
            <div className='background-Homeview'></div>
                <div className='card-center'>
                    <Card>
                        <Card.Body>
                            <h2 className="text-center mb-4"> Sign Up</h2>
                            <Form id="form" onSubmit={registerUser}>
                                <Form.Group id="email">
                                    <Form.Label>Email</Form.Label>
                                    <Form.Control name='Email' type="email" required placeholder="Email" id="email"></Form.Control>
                                </Form.Group>
                                <Form.Group id="password">
                                    <Form.Label>Password</Form.Label>
                                    <Form.Control name='Password' type="password" required placeholder="Password" id="password" onChange={validatePass} ref={passwordRef}></Form.Control>
                                </Form.Group>
                                <Form.Group id="birthday">
                                    <Form.Label>Birthday</Form.Label>
                                    <Form.Control name='Birthday' type="date" required placeholder="Birthday" id="birthday"></Form.Control>
                                </Form.Group>
                                <br></br>
                                <Button type="submit" className="btn-signup" id='btn-signup' disabled={disable}>
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


    
    function validatePass(event) {
        var password = event.target.value
        console.log(event.target.value)
        
        if (/^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&])[A-Z\d@$!%*#?&]{12,}$/.test(password)) {
            setDisable(false);
        }
        else{
            setDisable(true);
        }
    }

    function registerUser(event) {
        
        var data = {
            email: document.getElementById('email').value,
            password: document.getElementById('password').value,
            birthday: document.getElementById('birthday').value
        }
        
        event.preventDefault()
        console.log('start reg')
        
        fetch('http://localhost:3000/api/registration/register', {
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
