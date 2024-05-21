import { createContext, useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { LoginAPI, RegisterAPI } from "../Services/AuthService";
import { toast } from "react-toastify";
import React from "react";
import axios from "axios";

const UserContext = createContext({
  user: null,
  token: null,
  registerUser: (email, username, password) => {},
  loginUser: (username, password) => {},
  logout: () => {},
  isLoggedIn: () => false,
});

export const UserProvider = ({ children }) => {
  const navigate = useNavigate();
  const [token, setToken] = useState(null);
  const [user, setUser] = useState(null);
  const [isReady, setIsReady] = useState(false);

  useEffect(() => {
    const storedUser = localStorage.getItem("user");
    const storedToken = localStorage.getItem("token");
    if (storedUser && storedToken) {
      setUser(JSON.parse(storedUser));
      setToken(storedToken);
      axios.defaults.headers.common["Authorization"] = "Bearer " + storedToken;
    }
    setIsReady(true);
  }, []);

  const registerUser = async (email, username, password) => {
    try {
      const res = await RegisterAPI(email, username, password);
      if (res) {
        localStorage.setItem("token", res.token);
        const userObj = {
          userName: res.userName,
          email: res.email,
        };
        localStorage.setItem("user", JSON.stringify(userObj));
        setToken(res.token);
        setUser(userObj);
        toast.success("Registration Success!");
        navigate("/home");
      }
    } catch (e) {
      toast.warning("Server error occurred");
    }
  };

  const loginUser = async (username, password) => {
    try {
      const res = await LoginAPI(username, password);
      if (res) {
        localStorage.setItem("token", res.token);
        const userObj = {
          userName: res.userName,
          email: res.email,
        };
        localStorage.setItem("user", JSON.stringify(userObj));
        setToken(res.token);
        setUser(userObj);
        toast.success("Login Success!");
        navigate("/home");
      }
    } catch (e) {
      toast.warning("Server error occurred");
    }
  };

  const isLoggedIn = () => {
    return !!user;
  };

  const logout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    setUser(null);
    setToken(null);
    navigate("/");
  };

  return (
    <UserContext.Provider
      value={{ loginUser, user, token, logout, isLoggedIn, registerUser }}
    >
      {isReady ? children : null}
    </UserContext.Provider>
  );
};

export const useAuth = () => React.useContext(UserContext);
