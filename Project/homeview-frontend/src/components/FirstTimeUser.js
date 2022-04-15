import React from 'react'
import {Form, Button, Card, ToggleButton, ToggleButtonGroup} from 'react-bootstrap'
import {Link} from 'react-router-dom'


export default function FirstTimeUser() {
    const genres = [];
    const services = [];
    return (
            <div>
            <div className='background-Homeview'></div>
                <div className='card-center'>
                    <Card>
                        <Card.Body>
                            <h2 className="text-center mb-4"> Welcome to HomeView! </h2>
                            <p className="text-center mb-4"> Please fill out the form below to finish setting up your account.</p>

                            <Form id="form" onSubmit={SaveUserProfile}>
                                <Form.Group id="fName">
                                    <Form.Label>First Name</Form.Label>
                                    <Form.Control name='First Name' type="text" required placeholder="First Name" id="fName"></Form.Control>
                                </Form.Group>
                                <Form.Group id="lName">
                                    <Form.Label>Last Name</Form.Label>
                                    <Form.Control name='First Name' type="text" required placeholder="Last Name" id="lastName"></Form.Control>
                                </Form.Group>
                                <Form.Group id="dName">
                                    <Form.Label>Display Name</Form.Label>
                                    <Form.Control name='Display Name' type="text" required placeholder="Display Name" id="dName"></Form.Control>
                                </Form.Group>
                                <p>Select your genres!</p>
                                <Button style={ {backgroundColor:'gray'}} value='Action' id='Action' onClick={addtoGenres}>Action</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Romance' id='Romance' onClick={addtoGenres}>Romance</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Comedy' id='Comedy' onClick={addtoGenres}>Comedy</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Horror' id='Horror' onClick={addtoGenres}>Horror</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Thriller' id='Thriller' onClick={addtoGenres}>Thriller</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Slice of Life' id='sLICE' onClick={addtoGenres}>Slice of Life</Button>

                                <p> Select your streaming services!</p>
                                <Button style={ {backgroundColor:'gray'}} value='apple' id='apple' onClick={addtoServices}>Apple</Button>
                                <Button style={ {backgroundColor:'gray'}} value='disney' id='disney' onClick={addtoServices}>Disney</Button>
                                <Button style={ {backgroundColor:'gray'}} value='hbo' id='hbo' onClick={addtoServices}>HBO</Button>
                                <Button style={ {backgroundColor:'gray'}} value='hulu' id='hulu' onClick={addtoServices}>Hulu</Button>
                                <Button style={ {backgroundColor:'gray'}} value='mubi' id='mubi' onClick={addtoServices}>Mubi</Button>
                                <Button style={ {backgroundColor:'gray'}} value='netflix' id='netflix' onClick={addtoServices}>Netflix</Button>
                                <Button style={ {backgroundColor:'gray'}} value='paramount' id='paramount' onClick={addtoServices}>Paramount</Button>
                                <Button style={ {backgroundColor:'gray'}} value='peacock' id='peacock' onClick={addtoServices}>Peacock</Button>
                                <Button style={ {backgroundColor:'gray'}} value='prime' id='prime' onClick={addtoServices}>Prime</Button>
                                <Button style={ {backgroundColor:'gray'}} value='showtime' id='showtime' onClick={addtoServices}>Showtime</Button>
                                <Button style={ {backgroundColor:'gray'}} value='starz' id='starz' onClick={addtoServices}>Starz</Button>


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

    function addtoGenres(event) {
        if(event.target.style.backgroundColor !== 'gray') {
            event.target.style.backgroundColor='gray';
            if (genres.includes(event.target.value)) {
                const index = genres.indexOf(event.target.value);
                if (index > -1) {
                    genres.splice(index,1);                    
                }
            }
        }
        else {
            event.target.style.backgroundColor='green';
            genres.push(event.target.value);
        }
        console.log(genres);

    }

    function addtoServices(event) {
        if(event.target.style.backgroundColor !== 'gray') {
            event.target.style.backgroundColor='gray';
            if (services.includes(event.target.value)) {
                const index = services.indexOf(event.target.value);
                if (index > -1) {
                    services.splice(index,1);                    
                }
            }
        }
        else {
            event.target.style.backgroundColor='green';
            services.push(event.target.value);
        }
        console.log(services);
    }
    

    function SaveUserProfile(event) {

        var data = {
            fName: document.getElementById('fName').value,
            lName: document.getElementById('lName').value,
            dName: document.getElementById('dName').value,
            genreList : genres,
            serviceList : services

        }
        
        event.preventDefault()
        console.log('start firsttime form')
        
        fetch('http://localhost:3000/api/firsttime', {
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

        console.log('end firsttimeform')
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
