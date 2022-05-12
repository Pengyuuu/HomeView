import React from 'react';
import { Button } from 'react-bootstrap';

export default function PlaylistListTitle(title) {


    return (
        <>
            <li>{title.title.title}</li>
            <Button variant="outline-danger">Remove</Button>
        </>
    )
}