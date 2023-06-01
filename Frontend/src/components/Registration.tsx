import React from "react";
import { useState } from "react";
import {
  TextField,
  Button,
  Typography,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  Link,
} from "@mui/material";
import { Link as RouterLink } from "react-router-dom";
import { registration } from "../services/Auth";
import { useRecoilState } from "recoil";
import { tokenState, userState } from "../store/store";
import { useNavigate } from "react-router-dom";

interface RegistrationProps {}

const Registration: React.FC<RegistrationProps> = () => {
  const navigate = useNavigate();

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [role, setRole] = useState(0);
  const [username, setUsername] = useState("");

  const [token, setToken] = useRecoilState(tokenState);
  const [user, setUser] = useRecoilState(userState);

  const handleSubmit = async (e: any) => {
    await registration({ email, password, role, username }).then((data) => {
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
          Registration
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
          <FormControl sx={{ marginBottom: 2 }}>
            <InputLabel id="role-label">Select Role *</InputLabel>
            <Select
              labelId="role-label"
              id="role"
              value={role}
              onChange={(e) => setRole(+e.target.value)}
              required
            >
              <MenuItem value={0}>Volunteer</MenuItem>
              <MenuItem value={1}>Seeking Help</MenuItem>
            </Select>
          </FormControl>
          <Button
            onClick={handleSubmit}
            variant="contained"
            sx={{ marginBottom: 2 }}
          >
            Sign In
          </Button>
          <RouterLink to="/login">
            <Link>Already have an account?</Link>
          </RouterLink>
        </div>
      </div>
    </div>
  );
};

export default Registration;
