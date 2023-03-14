import "./App.css";
import background from "./assets/background.jpg";
import Header from "./components/Header";
import styles from "./styles/MainStyles";

function App() {
  return (
    <div className="App" style={{ ...styles.main }}>
      <Header />
    </div>
  );
}

export default App;
