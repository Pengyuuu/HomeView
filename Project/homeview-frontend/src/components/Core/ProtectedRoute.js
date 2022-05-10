import React from "react";
import { Navigate, Route } from "react-router-dom";
import Login from '../Core/Login'
import {Outlet} from "react-router";

const useAuth = () => {
  const {user} = {loggedIn: false};
  return user && user.loggedIn;
}

const ProtectedRoute = () => {
  const isAuth = useAuth();
  return isAuth? <Outlet/> : <Login />
}

export default ProtectedRoute;