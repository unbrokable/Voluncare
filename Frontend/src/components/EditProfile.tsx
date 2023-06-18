import React, { useState } from "react";
import {
  Button,
  TextField,
  Box,
  Avatar,
  CircularProgress,
} from "@mui/material";
import { userState } from "../store/store";
import { useRecoilState } from "recoil";
import { updateProfile, uploadAvatarImage } from "../services/Profile";
import { useNavigate } from "react-router-dom";
const EditProfile = () => {
  const [user, setUser] = useRecoilState(userState);
  const [error, setError] = useState(false);
  const navigate = useNavigate();
  const [name, setName] = useState(user.userName);
  const [email, setEmail] = useState(user.email);
  const [phone, setPhone] = useState(user.phoneNumber);
  const [avatar, setAvatar] = useState(null);
  const [avatarUrl, setAvatarUrl] = useState(user.avatarImage);
  const [loading, setLoading] = useState(false);
  const [loadingBtn, setLoadingBtn] = useState(false);

  const handleAvatarChange = async (e: any) => {
    setLoading(true);
    setAvatar(e.target.files[0]);

    await uploadAvatarImage(e.target.files[0])
      .then((response) => {
        setAvatarUrl(response.data.imageUrl);
      })
      .then(() => setLoading(false))
      .catch(() => setLoading(false));
  };

  const handleSubmit = async (e: any) => {
    setLoadingBtn(true);
    e.preventDefault();
    await updateProfile({
      id: user.id,
      avatarImage: avatarUrl,
      email: user.email,
      phoneNumber: phone,
    })
      .then((response) => {
        debugger;
        setUser(response.data.user);
        if (user.apllicationUserType === 0) {
          navigate("/vMain");
        } else if (user.apllicationUserType === 1) {
          navigate("/uMain");
        }
        setLoadingBtn(true);
      })
      .catch((er) => {
        setError(true);
        setLoadingBtn(true);
      });
  };

  return (
    <Box
      sx={{
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        height: "70vh", // Fill the viewport's height
      }}
    >
      <Box
        component="form"
        onSubmit={handleSubmit}
        sx={{
          display: "flex",
          justifyContent: "center",
          flexDirection: "column",
          alignItems: "center",
          backgroundColor: "#fff",
          padding: 2,
          width: "40%",
          borderRadius: 10,
        }}
        noValidate
        autoComplete="off"
      >
        {!loading && (
          <Avatar
            sx={{ width: 140, height: 140, marginBottom: 2 }}
            src={avatarUrl}
            alt="User avatar"
          />
        )}
        {loading && (
          <div style={{ marginBottom: 20 }}>
            <CircularProgress size={50} color="secondary" />
          </div>
        )}
        <input
          accept="image/*"
          id="contained-button-file"
          type="file"
          onChange={handleAvatarChange}
          style={{ display: "none" }}
        />
        <label htmlFor="contained-button-file">
          <Button
            variant="outlined"
            color="secondary"
            component="span"
            style={{ width: 240 }}
          >
            {avatar ? "Змінити аватар" : "Завантажити аватар"}
          </Button>
        </label>
        <TextField
          label="Name"
          value={name}
          onChange={(e) => setName(e.target.value)}
          disabled
          style={{ marginTop: 20, marginBottom: 20, width: 400 }}
        />
        <TextField
          label="Емейл"
          value={email}
          required
          onChange={(e) => setEmail(e.target.value)}
          style={{ marginBottom: 20, width: 400 }}
        />
        <TextField
          label="Номер телефону"
          value={phone}
          required
          error={error}
          onChange={(e) => {
            setPhone(e.target.value);
            setError(false);
          }}
          style={{
            marginBottom: 20,
            width: 400,
          }}
        />
        {!loadingBtn && (
          <Button
            type="submit"
            variant="contained"
            color="success"
            style={{ marginBottom: 20, width: 240 }}
          >
            Зберегти
          </Button>
        )}
        {loadingBtn && <CircularProgress color="success" />}
      </Box>
    </Box>
  );
};

export default EditProfile;
