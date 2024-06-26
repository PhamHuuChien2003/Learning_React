import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";

// import the library
import { library } from "@fortawesome/fontawesome-svg-core";

// import your icons
import { fab } from "@fortawesome/free-brands-svg-icons";
import { fas } from "@fortawesome/free-solid-svg-icons";
import { far } from "@fortawesome/free-regular-svg-icons";
import { faTwitter, faFontAwesome } from "@fortawesome/free-brands-svg-icons";
import "./App.css";
import "react-toastify/ReactToastify.css"
import LoginPage from "./Pages/LoginPage.jsx";
import HomePage from "./Pages/Homepage.jsx";
import { ToastContainer } from "react-toastify";

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          <Route exact path="/" element={<LoginPage  />} />
          <Route exact path="/home" element={<HomePage />} />
        </Routes>
      </BrowserRouter>
      <ToastContainer/>
    </div>
  );
}

export default App;
library.add(fab, fas, far, faTwitter, faFontAwesome);
