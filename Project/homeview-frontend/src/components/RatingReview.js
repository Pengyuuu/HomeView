import React, { useState } from 'react'
import {  Form, Button, Card } from 'react-bootstrap'
import { BsStar, BsStarFill, BsStarHalf} from 'react-icons/bs'
import { icons } from 'react-icons/lib';


//<script src='/Security.js'></script>
function Star({
    thresh,
    hoverValue,
    rating,
    handleHoverValue,
    handleSetRating, handleDoubleRating
}) {
    let isFilled = false;

    if (rating != null) {
        isFilled = rating >= thresh;
    } else {
        isFilled = hoverValue >= thresh;
    }
    if (isFilled) {
        if (thresh < rating || thresh < hoverValue) {
            return (
                <BsStarFill
                    color={"gold"}
                    size={50}
                    onClick={e => {
                        console.log(e.detail);

                        if (e.detail === 1) handleSetRating();
                        if (e.detail === 2) handleDoubleRating();
                    }}
                    
                    onMouseLeave={() => handleHoverValue(rating)}
                />
            );
        }
        else {
            return (
                <BsStarHalf
                    color={"gold"}
                    size={50}
                    onClick={e => {
                        console.log(e.detail);
                        if (e.detail === 1) handleSetRating();
                        if (e.detail === 2) handleDoubleRating();
                    }}
                    onMouseLeave={() => handleHoverValue(rating)}
                />
            );
        }
    } else {
        return (
            <BsStar
                color={"gold"}
                size={50}
                onMouseEnter={() => handleHoverValue(thresh)}
            />
        );
    }
}

export default function RatingReview() {
    const reviewRef = document.getElementById("");
    //const titleRef = this.title
    //const titleRef = document.getElementById("")                             
    const [rating, setRating] = useState(null);
    const [hoverValue, setHover] = useState(0);

    const handleSetRating = () => {
        if (rating != null) {
            setRating(null);
        }
        else {
            setRating(hoverValue);
        }
 
    };

    const handleDoubleRating = () => {
         setRating(hoverValue+0.5);
        
        
    };

    const handleHoverValue = (val) => {
        if (rating != null) {
            setHover(rating);

        }
        else {
            setHover(val);
        }
    };



    return (
       <>
       <div>
        <Card>
            <Card.Body>
                <br></br>
                <h3 className="text-center mb-4"> Create a Review</h3>

                        <Form id="reviewForm" onSubmit={SaveReview}>
                    <Form.Group  id="rating">
                                <Form.Label>Rating</Form.Label>
                                <Star
                                    thresh={0.5}
                                    hoverValue={hoverValue}
                                    rating={rating}
                                    handleHoverValue={handleHoverValue}
                                    handleSetRating={handleSetRating}
                                    handleDoubleRating={handleDoubleRating}
                                />
                                <Star
                                    thresh={1.5}
                                    hoverValue={hoverValue}
                                    rating={rating}
                                    handleHoverValue={handleHoverValue}
                                    handleSetRating={handleSetRating}
                                    handleDoubleRating={handleDoubleRating}
                                />
                                <Star
                                    thresh={2.5}
                                    hoverValue={hoverValue}
                                    rating={rating}
                                    handleHoverValue={handleHoverValue}
                                    handleSetRating={handleSetRating}
                                    handleDoubleRating={handleDoubleRating}
                                />
                                <Star
                                    thresh={3.5}
                                    hoverValue={hoverValue}
                                    rating={rating}
                                    handleHoverValue={handleHoverValue}
                                    handleSetRating={handleSetRating}
                                    handleDoubleRating={handleDoubleRating}
                                />
                                <Star
                                    thresh={4.5}
                                    hoverValue={hoverValue}
                                    rating={rating}
                                    handleHoverValue={handleHoverValue}
                                    handleSetRating={handleSetRating}
                                    handleDoubleRating={handleDoubleRating}
                                />
                                <div>{hoverValue}</div>

                    </Form.Group>
                    <Form.Group id="review">
                        <Form.Label>Review</Form.Label>
                        <textarea id="review" placeholder="Enter the text..." ref={reviewRef} required></textarea>
                    </Form.Group>
                    <br></br>
                    <Button className="w-100" type="submit" onClick={validateReview()}>
                        Sign Up
                    </Button>
                </Form>


            </Card.Body>
        </Card>

       </div>
    </>
    )


    function validateReview() {
        return false
    }

    function SaveReview() {
        return false
    }
}




