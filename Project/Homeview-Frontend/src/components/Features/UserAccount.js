import React, { Component, useState } from 'react'
import { Form, Button, Card } from 'react-bootstrap'
import { Link } from 'react-router-dom';
import Navigation from '../Navigation'
import BlacklistButton from '../Features/Blacklist/AccountButton'
import WatchLaterList from './WatchLater/WatchLaterList';
import ReviewList from './RatingReview/ReviewList';

//<script src='/Core/Security.js'></script>

export default function UserAccount() {

    return (
        <div>
            <div className='background-Homeview'></div>
            <Navigation />
            <div className='card-center'>
                <Card>
                    <Card.Body>
                        <h2 className="text-left">Account Details</h2>
                        <Form id="form">
                            <Form.Group id="email">
                                <Form.Label>Email</Form.Label>
                                <Form.Control name='Email' type="email" required id='email'></Form.Control>
                            </Form.Group>
                            <Button name="button" type="submit">Edit</Button>
                            <Form.Group id="password">
                                <Form.Label>Password</Form.Label>
                                <Form.Control name='Password' type="password" required id='password'></Form.Control>
                            </Form.Group>
                            <Button name="button" type="submit">Edit</Button>
                            <Form.Group id="displayName">
                                <Form.Label>Display Name</Form.Label>
                                <Form.Control name='displayName' type="displayName" required id='displayName'></Form.Control>
                            </Form.Group>
                            <Button name="button" type="submit">Edit</Button>
                        </Form>
                    </Card.Body>
                    <h3 className="text-left">Playlist</h3>
                    <Button name="button" href="/Playlist">+</Button>
                    <BlacklistButton />

                    <WatchLaterList />
                    <ReviewList />


                </Card>
            </div>
        </div>

    )
}
