import React from "react";
import { Button } from "react-bootstrap";

export default function AddToList(playlist, showTitle) {

    console.log(showTitle);
    return (
        <>
            <li>
                <Button>{playlist.playlist.playlistName}</Button>
            </li>
        </>
    )
}