import { Button } from "react-bootstrap";
import React from "react";

export default function WatchLater(title, year) {

    const AddToWatchLater = ({title, year}) => {
        const email = 'testing@gmail.com';

        var axios = require('axios');
        var data = JSON.stringify({
            "email": email,
            "title": title.title,
            "year": year.year
        });

        var config = {
            method: 'post',
            url: `http://54.219.16.154/api/WatchLater/${email}/${title}/${year}`,
            headers: {
                'Content-Type': 'application/json'
            },
            data: data
        };

        axios(config)
        .then(function (response) {
            console.log(JSON.stringify(response.data));

            alert(`Added ${title} (${year}) to Watch Later`)
        })
        .catch(function (error){
            
            console.log(error);

            alert("Unable to add")
        });
    }

    return (
        <div>
            <Button onClick={() => {AddToWatchLater(title, year)}}>Watch Later</Button>
        </div>
    );
}