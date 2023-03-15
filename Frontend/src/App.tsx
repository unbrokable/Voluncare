import "./App.css";
import Header from "./components/Header";

function App() {

  const { VITE_API_URL_API } = import.meta.env; 

  return (
    <div className="App">
      <Header />
      <div>Test variable {VITE_API_URL_API}</div>
    </div>
  );
}

export default App;
