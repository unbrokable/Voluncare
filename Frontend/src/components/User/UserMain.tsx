import {
  Button,
  CircularProgress,
  Pagination,
  Tab,
  Tabs,
  TextField,
} from "@mui/material";
import React, { useEffect, useState } from "react";
import {
  createHelpRequests,
  deleteHelpRequests,
  getUserHelpRequests,
} from "../../services/HelpRequests";
import { useRecoilState } from "recoil";
import {
  tokenState,
  userHelpRequestsState,
  userState,
} from "../../store/store";
import moment from "moment";
import { AccessTime, DeleteForever, Person } from "@mui/icons-material";
import { useNavigate } from "react-router-dom";

interface UserMainProps {}

const UserMain: React.FC<UserMainProps> = () => {
  const [activeTab, setActiveTab] = useState(0);
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [contactNumber, setContactNumber] = useState("");
  const [user, setUser] = useRecoilState(userState);
  const [token, setToken] = useRecoilState(tokenState);
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const handleTabChange = (event: any, newValue: number) => {
    setActiveTab(newValue);
  };

  const [userHelpRequests, setUserHelpRequests] = useRecoilState(
    userHelpRequestsState
  );

  useEffect(() => {
    getUserHelpRequests({
      userId: user?.id,
      page: 1,
      count: 5,
      token: token,
    }).then((data) => {
      setUserHelpRequests(data.data);
    });
  }, []);

  const handleSubmit = async () => {
    setLoading(true);
    await createHelpRequests({
      userId: user?.id,
      title: title,
      description: description,
      contactNumber: contactNumber,
      token: token,
    })
      .then(() => {
        setActiveTab(0), setTitle(""), setDescription(""), setContactNumber("");
        setLoading(false);
        getUserHelpRequests({
          userId: user?.id,
          page: 1,
          count: 5,
          token: token,
        }).then((data) => {
          setUserHelpRequests(data.data);
        });
      })
      .catch(() => setLoading(false));
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
      {activeTab === 0 && (
        <div style={{ padding: 20 }}>
          {
            <div style={{ padding: 40 }}>
              {userHelpRequests?.list.map(
                (request: {
                  userName: string;
                  title: string;
                  description: string;
                  contactNumber: string;
                  createDate: any;
                  status: number;
                  takenVolunteerId: string;
                  helpRequestId: string;
                }) => (
                  <div
                    style={
                      request.takenVolunteerId
                        ? {
                            minWidth: 275,
                            backgroundColor: "#68A691",
                            padding: 16,
                            boxShadow: "0 2px 4px rgba(0, 0, 0, 0.1)",
                            marginBottom: 20,
                          }
                        : {
                            minWidth: 275,
                            backgroundColor: "#FF9800",
                            padding: 16,
                            boxShadow: "0 2px 4px rgba(0, 0, 0, 0.1)",
                            marginBottom: 20,
                          }
                    }
                  >
                    <div
                      style={{
                        display: "flex",
                        flexDirection: "row",
                        alignItems: "center",
                        justifyContent: "space-between",
                      }}
                    >
                      <div>
                        <div
                          style={{
                            display: "flex",
                            flexDirection: "row",
                            alignItems: "center",
                          }}
                        >
                          <div>
                            <text
                              style={{
                                marginRight: 16,
                                fontWeight: 500,
                                fontSize: 24,
                                color: "white",
                              }}
                            >
                              {request.title}
                            </text>
                          </div>
                          <div
                            style={{ display: "flex", alignItems: "center" }}
                          >
                            <Person
                              style={{
                                height: 20,
                                width: 20,
                                color: "white",
                              }}
                            />
                            <text
                              style={{
                                marginLeft: 4,
                                marginRight: 16,
                                fontWeight: 500,
                                fontSize: 16,
                                color: "white",
                              }}
                            >
                              {user.userName}
                            </text>
                          </div>
                          <div
                            style={{ display: "flex", alignItems: "center" }}
                          >
                            <AccessTime
                              style={{
                                height: 20,
                                width: 20,
                                color: "white",
                              }}
                            />
                            <text
                              style={{
                                marginLeft: 4,
                                fontSize: 16,
                                color: "white",
                              }}
                            >
                              {moment(request.createDate).format(
                                "MMMM Do YYYY, h:mm a"
                              )}
                            </text>
                          </div>
                          <div
                            style={{
                              display: "flex",
                              alignItems: "center",
                              marginLeft: 16,
                              cursor: "pointer",
                            }}
                            onClick={() => {
                              deleteHelpRequests({
                                token,
                                requestId: request.helpRequestId,
                              }).then(() =>
                                getUserHelpRequests({
                                  userId: user?.id,
                                  page: 1,
                                  count: 5,
                                  token: token,
                                }).then((data) => {
                                  setUserHelpRequests(data.data);
                                })
                              );
                            }}
                          >
                            <DeleteForever
                              style={{
                                height: 20,
                                width: 20,
                                color: "red",
                              }}
                            />
                            <text
                              style={{
                                marginLeft: 4,
                                marginRight: 16,
                                fontWeight: 500,
                                fontSize: 16,
                                color: "red",
                              }}
                            >
                              Видалити
                            </text>
                          </div>
                        </div>

                        <div style={{ width: 1000 }}>
                          <text
                            style={{
                              marginRight: 12,
                              fontWeight: 400,
                              fontSize: 18,
                              color: "white",
                            }}
                          >
                            {request.description}
                          </text>
                        </div>
                      </div>

                      {request?.takenVolunteerId && (
                        <Button
                          onClick={() => {
                            navigate("/volunteer", {
                              state: { volunteerId: request?.takenVolunteerId },
                            });
                          }}
                          variant="contained"
                          style={{
                            width: 200,
                            marginLeft: 0,
                            marginRight: 50,
                            backgroundColor: "#EFC7C2",
                          }}
                        >
                          Профіль волонтеру
                        </Button>
                      )}
                    </div>
                  </div>
                )
              )}
              {/* <Pagination
                count={Math.ceil(totalCount / 5)}
                onChange={(event, page) => {
                  getUserHelpRequests({
                    page: page,
                    count: 5,
                    token: token,
                  }).then((data) => setUserHelpRequests(data.data));
                  setPage(page);
                }}
                showFirstButton
                showLastButton
              /> */}
            </div>
          }
        </div>
      )}
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
            {!loading && (
              <Button
                onClick={handleSubmit}
                variant="contained"
                color="success"
                sx={{ marginBottom: 2 }}
                disabled={
                  title.length === 0 || description.length === 0 || false
                }
              >
                Створити запит
              </Button>
            )}
            {loading && <CircularProgress color="success" />}
          </div>
        </div>
      )}
    </div>
  );
};

export default UserMain;
