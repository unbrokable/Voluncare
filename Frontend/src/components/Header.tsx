import { Button } from "@mui/material";
import logo from "../assets/react.svg";
import styles from "../styles/MainStyles";
import React from "react";

function Header() {
  return (
    <header style={{ ...styles.header }}>
      <img src={logo} alt="Your Logo" style={{ ...styles.logo }} />

      <text>HELP UKRAINE</text>

      <Button variant="contained" style={{ ...styles.button }}>
        GET STARTED
      </Button>
    </header>
  );
}

export default Header;
