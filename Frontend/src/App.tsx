import { RecoilRoot, useRecoilState } from "recoil";
import "./App.css";
import Header from "./components/Header";
import Home from "./components/Home";
import Login from "./components/Login";
import Registration from "./components/Registration";
import styles from "./styles/MainStyles";
import { Route, Routes, useNavigate } from "react-router-dom";
import VolunteerMain from "./components/Volunteer/VolunteerMain";
import EditProfile from "./components/EditProfile";
import UserMain from "./components/User/UserMain";
import { useEffect } from "react";
import { tokenState } from "./store/store";

function App() {
  const { VITE_API_URL_API } = import.meta.env;

  return (
    <RecoilRoot>
      <div className="App" style={{ ...styles.main }}>
        <Header />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/registration" element={<Registration />} />
          <Route path="/profile" element={<EditProfile />} />
          <Route path="/vMain" element={<VolunteerMain />} />
          <Route path="/uMain" element={<UserMain />} />
        </Routes>
      </div>
    </RecoilRoot>
  );
}

export default App;
