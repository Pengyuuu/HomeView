import React from 'react'
import { Form, Button, Card } from 'react-bootstrap'


//<script src='/Security.js'></script>

export default function () {
    const ratingRef = document.getElementById("")
    const reviewRef = document.getElementById("")
    //const titleRef = this.title
    const titleRef = document.getElementById("")

    return (
       <>
       < div >
        <Card>
            <Card.Body>
                <br></br>
                <h3 className="text-center mb-4"> Create a Review</h3>

                <Form>
                    <Form.Group  id="rating">
                        <Form.Label>Rating</Form.Label>
                        <Form.Control type="number" ref={ratingRef} required></Form.Control>
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
}

function validateReview() {
    return false
}
