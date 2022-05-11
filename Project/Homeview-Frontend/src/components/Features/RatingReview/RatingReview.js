import React, { useState } from 'react'
import { Form, Button, Card } from 'react-bootstrap'
import Star from './Star'


//<script src='/Security.js'></script>

export default function RatingReview({ title }) {
    const [review, setReview] = useState(null);
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
        setRating(hoverValue + 0.5);
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
        setReview(e.target.value);
    }


    return (
        <>
            <Card>
                <Card.Body className="color-style">
                    <br></br>
                    <h3 className="text-center" style={{ color: 'black' }}> Create a Review</h3>

                    <Form id="reviewForm">
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
                        <Form.Group className="text-center color-style" id="review" >
                            <br></br>
                            <textarea className="w-100" id="review" placeholder="Type your review here" onChange={handleCount} maxLength="2500"></textarea>
                            <p className="color-style">Character count: {count} (Max is 2500)</p>
                        </Form.Group>
                        <br></br>
                        <Button className="w-100" onClick={submitReview}>
                            Submit Review
                        </Button>
                    </Form>
                </Card.Body>
            </Card>

        </>
    )

    function submitReview() {
        console.log(title, rating, review);
        const dispNameTest = 'testName';
        const POST_URL = 'http://54.219.16.154/api/RatingReview/submit/' + title + '/' + dispNameTest + '?rating=' + rating + '&review=' + review
        //const POST_URL = 'https://localhost:7034/api/RatingReview/submit/' + title + '/' + dispNameTest + '?rating=' + rating + '&review=' + review

        fetch(POST_URL, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(res => {
            console.log(res)
            //return res.json()
        })
            .then(data => console.log("submitting review"))
        //return true;
    }
}




