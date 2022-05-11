// function to log user's access to a certain view
export default function LogAccess(viewId) {
    console.log("logging access")
    const token = window.sessionStorage.getItem('token');
    const POST_URL = 'http://54.219.16.154/api/Logging?viewId=' + { viewId } + '&token=' + token
    //const POST_URL = 'https://localhost:7034/api/Logging?viewId=' + viewId + '&token=' + "token"

    fetch(POST_URL, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(res => {
        console.log(res)
        //return res.json()
    })
        .then(data => console.log("submitting log"))
}