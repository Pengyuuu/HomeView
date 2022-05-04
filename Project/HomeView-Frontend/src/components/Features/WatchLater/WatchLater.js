import { Button } from "react-bootstrap";
/* test*/

export default function WatchLater() {

    function AddToWatchLater() {
        const email = 'testing@gmail.com';
        const title = 'Paranormal Activity';
        const year = '2007';

        const GET_URL = 'http://myhomeview.me/api/WatchLater/${email}/${title}/${year}';

        fetch(GET_URL, {

            method: 'GET',

            headers: { 'Content-Type': 'application/json' }
        }).then(res => {
            console.log(res);

            return res.json();
        }).then(data => console.log("reach"))

        return true;
    }

    return (
        <div>
            <Button className="mr-1" onClick={AddToWatchLater}>Watch Later</Button>
        </div>
    )
}