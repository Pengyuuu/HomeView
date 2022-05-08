import React from "react";
import { Navigate, Route } from "react-router-dom";

function ProtectedRoute({ user, children }) {
    if (user == null) {
        return <Navigate to="/login" replace />;
      }
    
      return children;

}

export default ProtectedRoute;