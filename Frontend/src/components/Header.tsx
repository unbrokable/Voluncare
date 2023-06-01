import { Button } from "@mui/material";
import logo from "../assets/logo.svg";
import styles from "../styles/MainStyles";
import { Link } from "react-router-dom";
import { tokenState } from "../store/store";
import { useRecoilState } from "recoil";
import { useNavigate } from "react-router-dom";

function Header() {
  const [token, setToken] = useRecoilState(tokenState);
  const navigate = useNavigate();
  return (
    <header style={{ ...styles.header }}>
      <Link to={token ? "/main" : "/"}>
        <img src={logo} alt="Your Logo" style={{ ...styles.logo }} />
      </Link>

      <Button
        variant="contained"
        style={{ ...styles.button }}
        onClick={() => {
          if (token) {
            setToken("");
            navigate("/");
          } else {
            navigate("/login");
          }
        }}
      >
        {token ? "LOGOUT" : "GET STARTED"}
      </Button>
    </header>
  );
}

export default Header;
