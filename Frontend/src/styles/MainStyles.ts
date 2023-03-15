import background from "../assets/background.jpg";

const colorSchema = {
  greenMain: "#68A691",
  greenSecondary: "#BFD3C1",
  redMain: "#FFE5D4",
  redSecondary: "#EFC7C2",
  purple: "#694F5D",
};

const styles = {
  main: {
    overflow: "hidden",
    height: "100vh",
    backgroundImage: `url(${background})`,
    backgroundRepeat: "no-repeat",
    backgroundSize: "cover",
  },
  button: {
    backgroundColor: colorSchema.greenMain,
  },
  header: {
    backgroundColor: colorSchema.greenSecondary,
    height: "80px",
    display: "flex",
    justifyContent: "space-between",
    alignItems: "center",
    padding: "0 1rem",
    opacity: 0.9,
  },
  logo: {
    height: "80px",
  },
};

export default styles;
