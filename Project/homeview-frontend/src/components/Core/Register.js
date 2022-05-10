import React from 'react'
import {Form, Button, Card} from 'react-bootstrap'
import {Link, useNavigate} from 'react-router-dom'
import AuthService from "./../../services/authentication"


export default function Register() {

    const [disable, setDisable] = React.useState(false);

    const navigate = useNavigate();

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

    const handleRegister = async (e) => {
        e.preventDefault()
        let email = e.target.Email.value;
        let password = e.target.Password.value;
        let birthday = e.target.birthday.value;

        try {
            await AuthService.register(email, password, birthday).then (
                () => {
                    navigate("/login");
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
                            <h2 className="text-center mb-4"> Sign Up</h2>
                            <Form id="form" onSubmit={handleRegister}>
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
}