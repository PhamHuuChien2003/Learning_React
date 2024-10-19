import React from "react";

import "./Login.css";

import * as Yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { useForm } from "react-hook-form";
import { useSignIn} from "../../Hooks/Auth/useSignIn"

// Validation schema without TypeScript type annotations
const validation = Yup.object().shape({
  userName: Yup.string().required("Username is required"),
  password: Yup.string().required("Password is required"),
});

export default function Login(props) {
  const  signIn  = useSignIn();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({ resolver: yupResolver(validation) });
  console.log("Chao Hieu")

  const handleLogin = (form) => {
    try {
      const username = form.userName;
      const password = form.password;
      signIn({username,password});
    } catch (error) {
      console.error("Login Error:", error);
    }
  };
  return (
    <>
      <div className="row">
        <div className="col-logo">
          <img src="./icon/fblg.svg" alt="Logo" />
          <h2>
            Facebook helps you connect and share with the people in your life.
          </h2>
        </div>
        <div className="col-form">
          <div className="form-container">
            <form onSubmit={handleSubmit(handleLogin)}>
              <input
                id="userName"
                {...register("userName")}
                type="text"
                placeholder="Email or phone number"
              />
              <input
                id="password"
                type="password"
                {...register("password")}
                placeholder="Password"
              />
              <button type="Submit" className="btn-login" >
                Login
              </button>
            </form>
            <a href="#">Forgotten password?</a>
            <button className="btn-new" type="submit">
              Create new Account
            </button>
          </div>
          <p>
            <a href="#">
              <b>Create a Page</b>
            </a>{" "}
            for a celebrity, brand or business.
          </p>
        </div>
      </div>
    </>
  );
}
