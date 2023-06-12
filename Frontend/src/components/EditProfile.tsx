import React, { useState } from "react";
import { Button, TextField, Box, Avatar } from "@mui/material";
import { userState } from "../store/store";
import { useRecoilState } from "recoil";
import { updateProfile, uploadAvatarImage } from "../services/Profile";
import { useNavigate } from "react-router-dom";
const EditProfile = () => {
  const [user, setUser] = useRecoilState(userState);
  const navigate = useNavigate();
  const [name, setName] = useState(user.userName);
  const [email, setEmail] = useState(user.email);
  const [phone, setPhone] = useState(user.phoneNumber);
  const [avatar, setAvatar] = useState(null);
  const [avatarUrl, setAvatarUrl] = useState(user.avatarImage);

  const handleAvatarChange = async (e: any) => {
    setAvatar(e.target.files[0]);

    await uploadAvatarImage(e.target.files[0]).then((response) => {
      setAvatarUrl(response.data.imageUrl);
    });
  };

  const handleSubmit = async (e: any) => {
    e.preventDefault();
    await updateProfile({
      id: user.id,
      avatarImage: avatarUrl,
      email: user.email,
      phoneNumber: phone,
    }).then((response) => {
      debugger;
      setUser(response.data.user);
      navigate("/main");
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
        <Avatar
          sx={{ width: 80, height: 80, marginBottom: 2 }}
          src={avatarUrl}
          alt="User avatar"
        />
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
            style={{ width: 200 }}
          >
            {avatar ? "Change Avatar" : "Upload Avatar"}
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
          label="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          style={{ marginBottom: 20, width: 400 }}
        />
        <TextField
          label="Phone number"
          value={phone}
          onChange={(e) => setPhone(e.target.value)}
          style={{ marginBottom: 20, width: 400 }}
        />
        <Button
          type="submit"
          variant="contained"
          color="success"
          style={{ marginBottom: 20, width: 200 }}
        >
          Save Changes
        </Button>
      </Box>
    </Box>
  );
};

export default EditProfile;
