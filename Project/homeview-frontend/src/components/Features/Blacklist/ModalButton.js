import React from "react";
import {Button} from 'react-bootstrap'

function ModalButton({items}) {
    console.log(items)
    return(
        items.length > 0 && items.map((item) => 
        <Button key = {item}>
            {item}
        </Button>)
    );
}
//<p>Genres: {genres.map((genre) => <Button>{genre}</Button>)}</p>
export default ModalButton;