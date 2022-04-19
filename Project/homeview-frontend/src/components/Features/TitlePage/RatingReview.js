import React, { useState } from 'react'
import {  Form, Button, Card } from 'react-bootstrap'
import Star from './Star'


//<script src='/Security.js'></script>
// need to check if user already has review data - if so, then load it first

export default function RatingReview() {
    const reviewRef = document.getElementById("id");
    // title should get passed
    //const titleRef = this.title
    //const titleRef = document.getElementById("")  
    const [count, currCount] = useState(0);
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
    const handleCount = (e) => {
        currCount(e.target.value.length);
    }


    return (
       <>
        <Card>
            <Card.Body>
                <br></br>
                <h3 className="text-center"> Create a Review</h3>

                        <Form id="reviewForm" onSubmit={SaveReview}>
                            <Form.Group className="text-center" id="rating">
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
                            <Form.Group className="text-center" id="review">
                                <br></br>

                            <textarea className="w-100" id="review" placeholder="Type your review here" onChange={handleCount} ref={reviewRef} maxLength="2500"></textarea>
                            <p>Character count: {count} (Max is 2500)</p>
                    </Form.Group>
                    <br></br>
                    <Button className="w-100" type="submit" onClick={validateReview}>
                        Submit Review
                    </Button>
                </Form>


            </Card.Body>
        </Card>

      
    </>
    )

    function validateReview() {
        return false
    }

    function SaveReview() {
        return false
    }

    function LoadReview() {

    }

    function UpdateReview() {

    }
}




