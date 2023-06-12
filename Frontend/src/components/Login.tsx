import { useState } from "react";
import {
  TextField,
  Button,
  Typography,
  Link,
  InputAdornment,
  IconButton,
} from "@mui/material";
import { Link as RouterLink } from "react-router-dom";
import { login } from "../services/Auth";
import { useRecoilState } from "recoil";
import { tokenState, userState } from "../store/store";
import { useNavigate } from "react-router-dom";
import { Visibility, VisibilityOff } from "@mui/icons-material";

const Login = () => {
  const navigate = useNavigate();

  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [showPassword, setShowPassword] = useState(false);

  const [token, setToken] = useRecoilState(tokenState);
  const [user, setUser] = useRecoilState(userState);

  const handleSubmit = async (e: any) => {
    await login({ username: username, password: password }).then((data) => {
      setToken(data.data.token);
      setUser(data.data.user);
      if (data.data.user.apllicationUserType === 0) {
        navigate("/vMain");
      } else if (data.data.user.apllicationUserType === 1) {
        navigate("/uMain");
      }
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
          Вхід
        </Typography>

        <div
          style={{
            display: "flex",
            flexDirection: "column",
          }}
        >
          <TextField
            label="Ім’я користувача"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            sx={{ marginBottom: 2 }}
            required
          />
          <TextField
            label="Пароль"
            type={showPassword ? "text" : "password"}
            InputProps={{
              endAdornment: (
                <InputAdornment position="end">
                  <IconButton
                    onClick={() => setShowPassword(!showPassword)}
                    edge="end"
                  >
                    {showPassword ? <VisibilityOff /> : <Visibility />}
                  </IconButton>
                </InputAdornment>
              ),
            }}
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
            Уввійти
          </Button>
          <RouterLink to="/registration">
            <Link>Ще не маєш аккаунту?</Link>
          </RouterLink>
        </div>
      </div>
    </div>
  );
};

export default Login;
