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
    height: "100vh",
    backgroundImage: `url(${background})`,
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
  homeTitle: {
    color: colorSchema.greenSecondary,
    fontSize: 34,
    fontWeight: 600,
    textAlign: "center",
    marginTop: 300,
    zIndex: 100,
  },
};

export default styles;
