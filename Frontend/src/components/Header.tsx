import { Button } from "@mui/material";
import logo from "../assets/logo.svg";
import styles from "../styles/MainStyles";
import { Link } from "react-router-dom";

function Header() {
  return (
    <header style={{ ...styles.header }}>
      <Link to="/">
        <img src={logo} alt="Your Logo" style={{ ...styles.logo }} />
      </Link>

      <text>HELP UKRAINE</text>

      <Link to="/login">
        <Button variant="contained" style={{ ...styles.button }}>
          GET STARTED
        </Button>
      </Link>
    </header>
  );
}

export default Header;
