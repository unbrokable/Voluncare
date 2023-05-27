import React from "react";
import styles from "../styles/MainStyles";

interface HomeProps {}

const Home: React.FC<HomeProps> = () => {
  return (
    <div
      style={{
        color: "#BFD3C1",
        fontSize: 34,
        fontWeight: 600,
        textAlign: "center",
        marginTop: 300,
        zIndex: 100,
      }}
    >
      УГА БУГА
    </div>
  );
};

export default Home;
