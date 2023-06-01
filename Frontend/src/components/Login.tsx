import { useState } from "react";
import { TextField, Button, Typography, Link } from "@mui/material";
import { Link as RouterLink } from "react-router-dom";
import { login } from "../services/Auth";
import { useRecoilState } from "recoil";
import { tokenState, userState } from "../store/store";
import { useNavigate } from "react-router-dom";

const Login = () => {
  const navigate = useNavigate();

  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const [token, setToken] = useRecoilState(tokenState);
  const [user, setUser] = useRecoilState(userState);

  const handleSubmit = async (e: any) => {
    await login({ username: username, password: password }).then((data) => {
      setToken(data.data.token);
      setUser(data.data.user);
      navigate("/main");
    });
  };

  return (
    <div
      style={{
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        height: "80%",
      }}
    >
      <div
        style={{
          display: "flex",
          flexDirection: "column",
          backgroundColor: "white",
          maxWidth: 400,
          padding: 80,
          borderRadius: 20,
        }}
      >
        <Typography variant="h4" sx={{ marginBottom: 2 }}>
          Login
        </Typography>

        <div
          style={{
            display: "flex",
            flexDirection: "column",
          }}
        >
          <TextField
            label="Username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            sx={{ marginBottom: 2 }}
            required
          />
          <TextField
            label="Password"
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            sx={{ marginBottom: 2 }}
            required
          />
          <Button
            onClick={handleSubmit}
            variant="contained"
            sx={{ marginBottom: 2 }}
          >
            Sign In
          </Button>
          <RouterLink to="/registration">
            <Link>Don’t have an account yet?</Link>
          </RouterLink>
        </div>
      </div>
    </div>
  );
};

export default Login;
