import { RecoilRoot, useRecoilState } from "recoil";
import "./App.css";
import Header from "./components/Header";
import Home from "./components/Home";
import Login from "./components/Login";
import Registration from "./components/Registration";
import styles from "./styles/MainStyles";
import { Route, Routes, useNavigate } from "react-router-dom";
import VolunteerMain from "./components/Volunteer/VolunteerMain";
import EditProfile from "./components/EditProfile";
import UserMain from "./components/User/UserMain";
import VolunteerPage from "./components/VolunteerPage";
import { ApplicationInsights } from "@microsoft/applicationinsights-web";
import {
  AppInsightsContext,
  ReactPlugin,
} from "@microsoft/applicationinsights-react-js";

function App() {
  const { VITE_API_URL_API } = import.meta.env;

  const reactPlugin = new ReactPlugin();

  const appInsights = new ApplicationInsights({
    config: {
      connectionString: `InstrumentationKey=1d4cff51-4963-4d66-98bc-bf420cef97ee;IngestionEndpoint=https://northeurope-2.in.applicationinsights.azure.com/;LiveEndpoint=https://northeurope.livediagnostics.monitor.azure.com/`,
      enableAutoRouteTracking: true,
      extensions: [reactPlugin],
    },
  });

  appInsights.loadAppInsights();

  return (
    // <AppInsightsContext.Provider value={reactPlugin}>
    <RecoilRoot>
      <div className="App" style={{ ...styles.main }}>
        <Header />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/registration" element={<Registration />} />
          <Route path="/profile" element={<EditProfile />} />
          <Route path="/vMain" element={<VolunteerMain />} />
          <Route path="/uMain" element={<UserMain />} />
          <Route path="/volunteer" element={<VolunteerPage />} />
        </Routes>
      </div>
    </RecoilRoot>
    // </AppInsightsContext.Provider>
  );
}

export default App;
