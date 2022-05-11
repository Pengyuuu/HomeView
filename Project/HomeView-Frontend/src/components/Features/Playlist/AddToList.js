import React from "react";
import { Button } from "react-bootstrap";

export default function AddToList(playlist) {

    return (
        <>
            <li>
                <Button>{playlist.playlist.playlistName}</Button>
            </li>
        </>
    )
}