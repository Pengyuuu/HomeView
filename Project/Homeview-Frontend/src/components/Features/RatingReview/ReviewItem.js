import React from 'react';
import { Button } from 'react-bootstrap';


function Remove(dispName, title) {
    var axios = require('axios');
    var data = JSON.stringify({
        "dispName": dispName,
        "title": title
    });
    var config = {
        method: "delete",
        url: `http://54.219.16.154/api/RatingReview/delete/title/user/${title}/${dispName}`,
        headers: {
            "Content-Type": "application/json"
        },
        data: data
    };

    axios(config).then(function (response) {
        console.log(JSON.stringify(response.data));
        alert(`Removed ${title} from Review List`)
    }).catch(function (error) {
        console.log(error);
    });
}

const ReviewItem = ({ rating, review, dispName, title }) => {
    if (title !== null) {
        return (<>
            <div>
                <div>
                    <h6>{title} - {rating} / 5</h6>
                    <p>{review}</p>
                    <Button variant="outline-danger" onClick={() => Remove(dispName, title)}>Remove</Button>
                    <br />
                </div>
            </div>
        </>
        )
    }
    else {
        return (<>

            <div>
                <div>
                    <h6>{dispName} - {rating} / 5</h6>
                    <p>{review}</p>
                    <br />
                </div>
            </div>
        </>
        )
    }
}

export default ReviewItem;