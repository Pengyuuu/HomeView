import React, { useState } from 'react'
import {  Form, Button, Card } from 'react-bootstrap'
import { BsStar, BsStarFill, BsStarHalf} from 'react-icons/bs'
import { icons } from 'react-icons/lib';


//<script src='/Security.js'></script>

export default function RatingReview() {
    const [starRating, setRating] = useState(0);
    const reviewRef = document.getElementById("");
    //const titleRef = this.title <Form.Control type="number" ref={ratingRef} required></Form.Control>
    //const titleRef = document.getElementById("")                                   <BsStar size="2x" id="rating" onClick={updateRating} />

    const handleRating = () => {
        updateRating();
        setRating(starRating);
    };

    function Star1(rating) {
        const values = [1, 2, 3, 4, 5];
        //const isClicked = false;
        // not clicked
        if (rating == 0) {

            return <BsStar color={"gold"} rating={rating} onClick={handleRating} size={50} />
        }
        // whole number
        else if (values.includes(rating)) {
            return <BsStarFill color={"gold"} onClick={handleRating} size={50} />
        }
        // half number
        else {
            return <BsStarHalf color={"gold"} onClick={handleRating} size={50} />
        }
    }



    function updateRating(event) {
        if (setRating !== 5) {
            setRating(setRating + 0.5);

        }
        else {
            setRating(0);

        }
        handleRating();
        console.log(setRating);
    }

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
                                <Star1 onClick={handleRating} />
                    </Form.Group>
                    <Form.Group id="review">
                        <Form.Label>Review</Form.Label>
                        <textarea id="review" placeholder="Enter the text..." ref={reviewRef} required></textarea>
                    </Form.Group>
                    <br></br>
                    <Button className="w-100" type="submit" onclick={validateReview()}>
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




