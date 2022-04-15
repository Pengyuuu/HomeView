import React from 'react'
import {Form, Button, Card} from 'react-bootstrap'


export default function FirstTimeUser() {
    const genres = [];
    const services = [];
    return (
            <div>
            <div className='background-Homeview'></div>
                <div className='card-long'>
                    <Card>
                        <Card.Body>
                            <h2 className="text-center"> Welcome to HomeView! </h2>
                            <p className="text-center "> Please fill out the form below to finish setting up your account.</p>

                            <Form id="form" onSubmit={SaveUserProfile}>
                                <Form.Group id="fName">
                                    <Form.Label>First Name</Form.Label>
                                    <Form.Control name='First Name' type="text" required placeholder="First Name" id="fName"></Form.Control>
                            </Form.Group>
                            <br></br>
                                <Form.Group id="lName">
                                    <Form.Label>Last Name</Form.Label>
                                    <Form.Control name='First Name' type="text" required placeholder="Last Name" id="lastName"></Form.Control>
                            </Form.Group>
                            <br></br>

                                <Form.Group id="dName">
                                    <Form.Label>Display Name</Form.Label>
                                    <Form.Control name='Display Name' type="text" required placeholder="Display Name" id="dName"></Form.Control>
                            </Form.Group>
                            <br></br>

                            <p>Select your genres!</p>

                                <Button style={ {backgroundColor:'gray'}} value='Biography' id='Biography' onClick={addtoGenres}>Biography</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Film Noir' id='Film Noir' onClick={addtoGenres}>Film Noir</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Game Show' id='Game Show' onClick={addtoGenres}>Game Show</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Musical' id='Musical' onClick={addtoGenres}>Musical</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Sport' id='Sport' onClick={addtoGenres}>Sport</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Short' id='Short' onClick={addtoGenres}>Short</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Adult' id='Adult' onClick={addtoGenres}>Adult</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Adventure' id='Adventure' onClick={addtoGenres}>Adventure</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Fantasy' id='Fantasy' onClick={addtoGenres}>Fantasy</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Animation' id='Animation' onClick={addtoGenres}>Animation</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Drama' id='Drama' onClick={addtoGenres}>Drama</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Horror' id='Horror' onClick={addtoGenres}>Horror</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Action' id='Action' onClick={addtoGenres}>Action</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Comedy' id='Comedy' onClick={addtoGenres}>Comedy</Button>
                                <Button style={ {backgroundColor:'gray'}} value='History' id='History' onClick={addtoGenres}>History</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Western' id='Western' onClick={addtoGenres}>Western</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Thriller' id='Thriller' onClick={addtoGenres}>Thriller</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Crime' id='Crime' onClick={addtoGenres}>Crime</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Documentary' id='Documentary' onClick={addtoGenres}>Documentary</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Science Fiction' id='Science Fiction' onClick={addtoGenres}>Science Fiction</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Mystery' id='Mystery' onClick={addtoGenres}>Mystery</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Music' id='Music' onClick={addtoGenres}>Music</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Romance' id='Romance' onClick={addtoGenres}>Romance</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Family' id='Family' onClick={addtoGenres}>Family</Button>
                                <Button style={ {backgroundColor:'gray'}} value='War' id='War' onClick={addtoGenres}>War</Button>
                                <Button style={ {backgroundColor:'gray'}} value='News' id='News' onClick={addtoGenres}>News</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Reality' id='Reality' onClick={addtoGenres}>Reality</Button>
                                <Button style={ {backgroundColor:'gray'}} value='Talk Show' id='Talk Show' onClick={addtoGenres}>Talk Show</Button>
                            <br></br>
                            <br></br>

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
                            <Button style={{ backgroundColor: 'gray' }} value='starz' id='starz' onClick={addtoServices}>Starz</Button>
                            <br></br>
                            <br></br>


                                <Button type="submit" className="btn-signup center">
                                    Sign Up
                                </Button>
                            </Form >
                            
                        </Card.Body>
                    </Card>
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