import React from 'react'
import {Form, Button, Card} from 'react-bootstrap'
import {Link} from 'react-router-dom'


export default function Register() {

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
                                    <Form.Control name='Password' type="password" required placeholder="Password" id="password" onChange={validatePass}></Form.Control>
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
        // uncomment to see password on console as you type
        //console.log(password)
        if (/^(?=.*[A-Z])(?=.*?[#?!@$%^&*-]).{12,}$/.test(password)) {
            setDisable(false);
        }
        else{
            setDisable(true);
        }
    }

    function registerUser(event) {
        event.preventDefault()
        
        let email = event.target.Email.value;
        let password = event.target.Password.value;
        let birthday = event.target.birthday.value;
        console.log(email)
        var data = {
            email: email,
            password: password,
            birthday: birthday 
        }
        
        console.log('start reg')

        var axios = require('axios');
        var config = {
            method: 'post',
            url: `http://54.219.16.154/api/registration?email=${email}&dob=${birthday}&pw=${password}`,
            headers: {},
            data: data
        };

        axios(config)
        .then(function (response) {
        console.log(JSON.stringify(response.data));
        alert("registered successfully")
        })
        .catch(function (error) {
        console.log(error);
        alert("unable to register")
        });

        console.log('end reg')
    }
}