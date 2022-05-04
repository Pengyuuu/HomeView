import { Button } from "react-bootstrap";
import React from "react";

export default function WatchLater() {

    const AddToWatchLater = ({title, year}) => {
        const email = 'testing@gmail.com';

        const POST_URL = `http://myhomeview.me/api/WatchLater/${email}/${title}/${year}`;

        fetch(POST_URL, {

            method: 'POST',

            headers: { 'Content-Type': 'application/json' }
        }).then(res => {
            console.log(res);

            return res.json();
        })

        return true;
    }

    return (
        <div>
            <Button onClick={AddToWatchLater}>Watch Later</Button>
        </div>
    );
}