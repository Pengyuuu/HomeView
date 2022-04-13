import React, {useState, useRef} from 'react'
import {Form, Button, Card} from 'react-bootstrap'
import {Link} from 'react-router-dom'
import axios from 'axios';

export default function Register(props) {

    const[data, setdata] = useState({Email:'', Password:'', Birthday:''})
    const apiURL = "api/registration/register";

    const Registration = (e) => {
        e.preventDefault();
        //debugger;
        const userData = {
            Email: data.email,
            Password: data.password,
            Birthday: data.birthday
        };

        axios.get("api/registration/validate", userData)
            .then((result) => {
                //debugger;
                console.log(result.data);
                if (result.data.Status === 'Invalid')
                    alert('Invalid User');
                else
                    axios.post(apiURL, userData)
                        .then((result) => {
                            //debugger;
                            console.log(result.data);
                            if (result.data.Status === 'Invalid')
                                alert('Invalid User');
                            else
                                //props.history.push('/EmailSent');
                                alert('Confirmation email sent.');
                        })
                    //props.history.push('/Home');
            })

      
    }

    const emailRef = useRef()
    const passwordRef = useRef()
    const birthdayRef = useRef()
    
    const onChange = (e) => {
        //e.persist();
       // debugger;
        setdata({...data, [e.target.name]: e.target.value});
    }

    return (
            <div>
            <div className='background-Homeview'></div>
                <div className='card-center'>
                    <Card>
                        <Card.Body>
                            <h2 className="text-center mb-4"> Sign Up</h2>
                            <Form onSubmit={Registration}>
                                <Form.Group id="email">
                                    <Form.Label>Email</Form.Label>
                                    <Form.Control name = 'Email' type="email" ref={emailRef} required placeholder="Email" onChange={onChange} value={data.Email}></Form.Control>
                                </Form.Group>
                                <Form.Group id="password">
                                    <Form.Label>Password</Form.Label>
                                    <Form.Control name = 'Password' type="password" ref={passwordRef} required placeholder="Password" onChange={onChange} value={data.Password}></Form.Control>
                                </Form.Group>
                                <Form.Group id="birthday">
                                    <Form.Label>Birthday</Form.Label>
                                    <Form.Control name = 'Birthday' type="date" ref={birthdayRef} required placeholder="Birthday" onChange={onChange} value={data.Birthday}></Form.Control>
                                </Form.Group>
                                <br></br>
                                <Button className="btn-signup" type="submit">
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
}


