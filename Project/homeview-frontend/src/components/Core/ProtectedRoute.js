import React from "react";
import { Navigate, Route } from "react-router-dom";

function ProtectedRoute({ user, children }) {
    if (!user) {
        return <Navigate to="/login" replace />;
      }
    
      return children;

}

export default ProtectedRoute;