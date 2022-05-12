import React, { useState }  from "react";
import Login from './Core/Login';
import AuthService from "./../services/authentication"
import {Outlet} from "react-router-dom";

const ProtectedRoutes = () => {
    const [auth, setAuth] = useState("false");

    AuthService.validate().then(response => {
        setAuth(response);
    });
    return auth ? <Outlet/> : <Login/>;
};

export default ProtectedRoutes;