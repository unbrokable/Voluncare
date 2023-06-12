import { Button, Tab, Tabs, TextField } from "@mui/material";
import React, { useState } from "react";
import { createHelpRequests } from "../../services/HelpRequests";
import { useRecoilState } from "recoil";
import { tokenState, userState } from "../../store/store";

interface UserMainProps {}

const UserMain: React.FC<UserMainProps> = () => {
  const [activeTab, setActiveTab] = useState(0);
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [contactNumber, setContactNumber] = useState("");
  const [user, setUser] = useRecoilState(userState);
  const [token, setToken] = useRecoilState(tokenState);

  const handleTabChange = (event: any, newValue: number) => {
    setActiveTab(newValue);
  };

  const handleSubmit = async () => {
    await createHelpRequests({
      userId: user?.id,
      title: title,
      description: description,
      contactNumber: contactNumber,
      token: token,
    }).then(() => setActiveTab(0));
  };
  return (
    <div style={{ width: "100%", height: "91.5%", backgroundColor: "white" }}>
      <Tabs
        value={activeTab}
        onChange={handleTabChange}
        textColor="secondary"
        indicatorColor="secondary"
        variant="fullWidth"
      >
        <Tab label="Ваші запити" style={{ fontWeight: "600" }} />
        <Tab label="Створити запит на допомогу" style={{ fontWeight: "600" }} />
      </Tabs>
      {activeTab === 0 && <div style={{ padding: 20 }}>GOGO</div>}
      {activeTab === 1 && (
        <div
          style={{
            padding: 20,
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            height: "70%",
          }}
        >
          <div
            style={{
              display: "flex",
              flexDirection: "column",
              width: "30%",
              border: "3px solid #FFE5D4",
              borderRadius: 20,
              padding: 80,
            }}
          >
            <text style={{ marginBottom: 10, fontWeight: 500, fontSize: 18 }}>
              Створення запиту на допомогу
            </text>
            <TextField
              label="Заголовок"
              value={title}
              onChange={(e) => setTitle(e.target.value)}
              sx={{ marginBottom: 2 }}
              required
            />
            <TextField
              label="Контактний номер телефону"
              value={contactNumber}
              onChange={(e) => setContactNumber(e.target.value)}
              sx={{ marginBottom: 2 }}
              required
            />
            <TextField
              label="Опис"
              multiline
              value={description}
              onChange={(e) => setDescription(e.target.value)}
              sx={{
                marginBottom: 2,
                "& .MuiInputBase-root": {
                  height: "200px", // Adjust the height value as needed
                },
              }}
              required
            />
            <Button
              onClick={handleSubmit}
              variant="contained"
              color="success"
              sx={{ marginBottom: 2 }}
              disabled={title.length === 0 || description.length === 0 || false}
            >
              Створити запит
            </Button>
          </div>
        </div>
      )}
    </div>
  );
};

export default UserMain;
