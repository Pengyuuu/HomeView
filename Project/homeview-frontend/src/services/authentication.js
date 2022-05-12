import axios from 'axios';

//const API_URL = `${process.env.REACT_APP_WEB_API}`
const API_URL = "https://localhost:7034/api"

const login = (email, password) => {
    return axios
    .get(API_URL + `/login/?email=${email}&pw=${password}`)
    .then((response) => {
        if (response.data != null) {
            sessionStorage.setItem("token", response.data);
        }
        return response.data;
    });
};

const register = (email, password, birthday) => {
    return axios
    .post(API_URL + `/registration/?email=${email}&dob=${birthday}&pw=${password}`)
    .then((response) => {
        if(response.data!= null) {
            sessionStorage.setItem("token", response.data);
        }
        return response.data;
    });
};

const logout = () => {
    sessionStorage.removeItem("token");
}

const validate = () => {
    let axios = require('axios');

    let config = {
        method: 'get',
        url: API_URL + '/login/validate',
        headers: {'Authorization': sessionStorage.getItem("token")}
    };

    return axios(config)
        .then(function (response) {
            return true;
        })
        .catch(function (error) {
            return false;
        });
}

const AuthService = {
    login,
    register,
    logout,
    validate
};
export default AuthService;