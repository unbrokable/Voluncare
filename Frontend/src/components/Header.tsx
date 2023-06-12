import { Button } from "@mui/material";
import logo from "../assets/logo.svg";
import profile from "../assets/profile.svg";
import styles from "../styles/MainStyles";
import { Link } from "react-router-dom";
import { tokenState, userState } from "../store/store";
import { useRecoilState } from "recoil";
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";

function Header() {
  const [token, setToken] = useRecoilState(tokenState);
  const [user, setUser] = useRecoilState(userState);
  const navigate = useNavigate();

  useEffect(() => {
    if (!token) {
      navigate("/");
    }
  }, []);

  return (
    <header style={{ ...styles.header }}>
      <Link
        to={
          token ? (user.apllicationUserType === 0 ? "/vMain" : "/uMain") : "/"
        }
      >
        <img src={logo} alt="Your Logo" style={{ ...styles.logo }} />
      </Link>

      <div style={{ display: "flex", alignItems: "center" }}>
        {token ? (
          <Link to="/profile">
            {user?.avatarImage ? (
              <img
                src={user?.avatarImage}
                alt="Your profile"
                style={{
                  width: 60,
                  height: 60,
                  marginRight: 14,
                  borderRadius: 30,
                }}
              />
            ) : (
              <img
                src={profile}
                alt="Your profile"
                style={{ width: 60, height: 60, marginRight: 14 }}
              />
            )}
          </Link>
        ) : null}

        <Button
          variant="contained"
          style={{ ...styles.button }}
          onClick={() => {
            if (token) {
              setToken("");
              navigate("/");
            } else {
              navigate("/login");
            }
          }}
        >
          {token ? "Вийти" : "Розпочати"}
        </Button>
      </div>
    </header>
  );
}

export default Header;
