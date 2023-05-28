import { useState } from "react";
import { TextField, Button, Typography, Link } from "@mui/material";
import { Link as RouterLink } from "react-router-dom";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = (e: any) => {
    e.preventDefault();
    // Handle form submission logic here
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
        <form onSubmit={handleSubmit}>
          <div
            style={{
              display: "flex",
              flexDirection: "column",
            }}
          >
            <TextField
              label="Email"
              type="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
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
            <Button type="submit" variant="contained" sx={{ marginBottom: 2 }}>
              Sign In
            </Button>
            <RouterLink to="/registration">
              <Link>Don’t have an account yet?</Link>
            </RouterLink>
          </div>
        </form>
      </div>
    </div>
  );
};

export default Login;
