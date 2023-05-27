import React from "react";
import styles from "../styles/MainStyles";

interface HomeProps {}

const Home: React.FC<HomeProps> = () => {
  return <div style={{ ...styles.homeTitle }}>УГА БУГА</div>;
};

export default Home;
