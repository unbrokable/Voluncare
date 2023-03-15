import "./App.css";
import background from "./assets/background.jpg";
import Header from "./components/Header";
import styles from "./styles/MainStyles";

function App() {

  const { VITE_API_URL_API } = import.meta.env; 

  return (
    <div className="App" style={{ ...styles.main }}>
      <Header />
      <div>Test variable {VITE_API_URL_API}</div>
    </div>
  );
}

export default App;
