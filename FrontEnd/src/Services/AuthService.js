import axios from "axios";
import { handleError } from "../Helpers/ErrorHandler.jsx";

const api = "http://localhost:5149/api/";


export const LoginAPI = async (username, password) => {
  try {
    const res = await axios.post(api + "account/login", {
      username: username,
      password: password,
    });
    return res;
  } catch (error) {
    handleError(error);
  }
};

export const RegisterAPI = async (email, username, password) => {
  try {
    const data = await axios.post(api + "account/register", {
      username: username,
      password: password,
      email: email,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};
