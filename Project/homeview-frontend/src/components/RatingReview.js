export default function (title) {
    const ratingRef = useRef()
    const reviewRef = useRef()
    const titleRef = this.title

    return (
       <>
       < div >
        <Card>
            <Card.Body>
                <h2 className="text-center mb-4"> Ratings and Reviews</h2>
                <br></br>
                <h3 className="text-center mb-4"> Create a Review</h3>

                <Form>
                    <Form.Group id="rating">
                        <Form.Label>Rating</Form.Label>
                        <Form.Control type="int" ref={ratingRef} required></Form.Control>
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

                <LoadReviews> </LoadReviews>

            </Card.Body>
        </Card>

       </div>
       </>
        )
}

function validateReview() {
    if (reviewRef.length)
}
