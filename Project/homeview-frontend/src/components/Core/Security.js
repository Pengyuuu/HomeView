
/*
(() => {

    function isValid(token) {
        var isJwt = token && window.jwt_decode(token)
    

        if (isJwt) {
            return true;
        }
        return false;
    }

    function authorizeView() {
        const token = window.sessionStorage.getItem('token');

        if (!isValid(token)) {
            window.location.assign(window.location.origin)
        }
        window.onload = authorizeView;
    }
})()*/