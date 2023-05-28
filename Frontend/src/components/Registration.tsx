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

interface RegistrationProps {}

const Registration: React.FC<RegistrationProps> = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [role, setRole] = useState("");

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
            <FormControl sx={{ marginBottom: 2 }}>
              <InputLabel id="role-label">Select Role *</InputLabel>
              <Select
                labelId="role-label"
                id="role"
                value={role}
                onChange={(e) => setRole(e.target.value)}
                required
              >
                <MenuItem value="volunteer">Volunteer</MenuItem>
                <MenuItem value="seekingHelp">Seeking Help</MenuItem>
              </Select>
            </FormControl>
            <Button type="submit" variant="contained" sx={{ marginBottom: 2 }}>
              Sign In
            </Button>
            <RouterLink to="/login">
              <Link>Already have an account?</Link>
            </RouterLink>
          </div>
        </form>
      </div>
    </div>
  );
};

export default Registration;
