import { useNavigate } from "react-router-dom";
import "./Login.css";

export default function Login() {

    const navigate = useNavigate();


    return (
    <>
      <div class="row">
        <div class="col-logo">
          <img
            src="./icon/fblg.svg"
            alt="Logo"
          />
          <h2>
            Facebook helps you connect and share with the people in your life.
          </h2>
        </div>
        <div class="col-form">
          <div class="form-container">
            <input type="text" placeholder="Email or phone number" />
            <input type="password" placeholder="Password" />
            <button class="btn-login" onClick={()=>navigate("/home")}>Login</button>
            <a href="#">Forgotten password?</a>
            <button class="btn-new">Create new Account</button>
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
