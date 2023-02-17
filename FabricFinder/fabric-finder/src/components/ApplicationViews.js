import React from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import Login from "./Login";
import Register from "./Register";
import FabricList from "./FabricList";
import FabricForm from "./FabricForm";
import { EditFabric } from "./EditFabricForm";
import PatternForm from "./PatternForm";

export default function ApplicationViews({ isLoggedIn }) {

    return (
        <Routes>
            <Route path="/">
                <Route
                    index
                    element={isLoggedIn ? <FabricList /> : <Navigate to="/login" />}
                />
                <Route
                    path="addFabric"
                    element={isLoggedIn ? <FabricForm /> : <Navigate to="/login" />}
                />
                <Route
                    path="addPattern"
                    element={isLoggedIn ? <PatternForm /> : <Navigate to="/login" />}
                />
                <Route
                    path="updateFabric/:fabricId"
                    element={isLoggedIn ? <EditFabric /> : <Navigate to="/login" />}
                />
                <Route path="login" element={<Login />} />
                <Route path="register" element={<Register />} />
                <Route path="*" element={<p>Whoops, nothing here...</p>} />
            </Route>
        </Routes>
    );
}



