import axios from 'axios';

const API_URL = `${process.env.REACT_APP_WEB_API}`

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

const AuthService = {
    login,
    register,
    logout
};
export default AuthService;