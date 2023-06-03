import { RecoilRoot } from "recoil";
import "./App.css";
import Header from "./components/Header";
import Home from "./components/Home";
import Login from "./components/Login";
import Registration from "./components/Registration";
import styles from "./styles/MainStyles";
import { Route, Routes } from "react-router-dom";
import VolunteerMain from "./components/Volunteer/VolunteerMain";
import EditProfile from "./components/EditProfile";

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
          {/* add dependency on role */}
          <Route path="/main" element={<VolunteerMain />} />
        </Routes>
      </div>
    </RecoilRoot>
  );
}

export default App;
