import React, { useEffect, useState } from "react";
import { getUserInfo } from "../services/User";
import { useRecoilState } from "recoil";
import {
  acceptedHelpRequestState,
  commentsState,
  tokenState,
  userState,
  volunteerState,
} from "../store/store";
import { useLocation } from "react-router-dom";
import {
  Avatar,
  Button,
  List,
  ListItem,
  ListItemText,
  TextField,
} from "@mui/material";
import {
  AccessTime,
  Hotel,
  Person,
  Star,
  StarBorder,
} from "@mui/icons-material";
import { getComments, postComment } from "../services/Comments";
import moment from "moment";
import { getAcceptedHelpRequests } from "../services/HelpRequests";

interface VolunteerPageProps {}

const VolunteerPage: React.FC<VolunteerPageProps> = () => {
  const [token, setToken] = useRecoilState(tokenState);
  const [user, setUser] = useRecoilState(userState);
  const [volunteer, setVolunteer] = useRecoilState(volunteerState);
  const [comments, setComments] = useRecoilState(commentsState);
  const [acceptedHR, setAcceptedHR] = useRecoilState(acceptedHelpRequestState);
  const { state } = useLocation();
  const { volunteerId } = state;

  useEffect(() => {
    getUserInfo({ userId: volunteerId, token })
      .then((data) => {
        setVolunteer(data.data);
        console.log(data.data);
      })
      .catch(() => {});
    getComments({ receiverId: volunteerId, token }).then((data) => {
      setComments(data.data);
    });
    getAcceptedHelpRequests({
      page: 1,
      count: 3,
      token: token,
      volunteerId,
    }).then((data) => setAcceptedHR(data.data));
  }, []);

  const [newComment, setNewComment] = useState("");

  const handleCommentChange = (event: any) => {
    setNewComment(event.target.value);
  };

  const handleCommentSubmit = () => {
    postComment({
      userId: user.id,
      receiverId: volunteerId,
      token,
      text: newComment,
    }).then(() => {
      getComments({ receiverId: volunteerId, token }).then((data) =>
        setComments(data.data)
      );
      setNewComment("");
    });
  };

  return (
    <div
      style={{
        width: "100%",
        height: "91.5%",
        backgroundColor: "white",
        display: "flex",
        flexDirection: "row",
      }}
    >
      <div style={{ padding: 20, display: "flex", flexDirection: "column" }}>
        <div style={{ display: "flex", flexDirection: "row" }}>
          <Avatar
            sx={{ width: 200, height: 200, marginBottom: 2 }}
            src={volunteer.result.avatarImage}
            alt="User avatar"
          />
          <div style={{ marginLeft: 100 }}>
            <div style={{ fontSize: 30, fontWeight: 500 }}>
              {`Ім’я користувача: ${volunteer.result.userName}`}
            </div>
            <div style={{ fontSize: 24, fontWeight: 400 }}>
              {`Контактний телефон: ${volunteer.result.phoneNumber}`}
            </div>
            <div style={{ fontSize: 30, fontWeight: 500 }}>
              {Array(volunteer.result.averageRating)
                .fill(0)
                .map((num) => (
                  <Star style={{ color: "gold" }} />
                ))}
              {Array(5 - volunteer.result.averageRating)
                .fill(0)
                .map((num) => (
                  <StarBorder style={{ color: "gold" }} />
                ))}
            </div>
          </div>
        </div>
        <div
          style={{
            height: 700,
            width: 950,
            backgroundColor: "#EDE9F2",
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            borderRadius: 30,
          }}
        >
          {acceptedHR.list.length && (
            <div>
              {acceptedHR.list.map(
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
                    style={{
                      minWidth: 100,
                      backgroundColor: "#8F85DF",
                      padding: 16,
                      boxShadow: "0 2px 4px rgba(0, 0, 0, 0.1)",
                      marginBottom: 20,
                    }}
                  >
                    <div
                      style={{
                        display: "flex",
                        flexDirection: "column",
                        alignItems: "flex-start",
                      }}
                    >
                      <div
                        style={{
                          display: "flex",
                          flexDirection: "row",
                          alignItems: "center",
                        }}
                      >
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

                        <div style={{ display: "flex", alignItems: "center" }}>
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
                            {request?.userName}
                          </text>
                        </div>
                        <div style={{ display: "flex", alignItems: "center" }}>
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
                      </div>
                    </div>
                    <div
                      style={{
                        width: 850,
                      }}
                    >
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
                )
              )}
            </div>
          )}
          {!acceptedHR.list.length && (
            <div style={{ display: "flex", flexDirection: "row" }}>
              <div style={{ marginRight: 8, fontSize: 16, fontWeight: 500 }}>
                Зараз волонтер не має роботи
              </div>
              <Hotel />
            </div>
          )}
        </div>
      </div>
      <div
        style={{
          position: "absolute",
          bottom: 20,
          right: 100,
        }}
      >
        <List style={{ height: 600, overflowY: "auto" }}>
          {comments.map(
            (
              comment: { text: string; userName: string; date: any },
              index: number
            ) => {
              return (
                <ListItem
                  style={{
                    backgroundColor: "lightgray",
                    borderRadius: 20,
                    marginBottom: 20,
                  }}
                  key={index}
                >
                  <div style={{ display: "flex", flexDirection: "column" }}>
                    <div style={{ display: "flex" }}>
                      <div style={{ marginRight: 16, fontWeight: 600 }}>
                        {comment.userName}
                      </div>
                      <div>{moment(comment.date).calendar()}</div>
                    </div>
                    <ListItemText primary={comment?.text} />
                  </div>
                </ListItem>
              );
            }
          )}
        </List>
        <div style={{ display: "flex", flexDirection: "column" }}>
          <TextField
            style={{ marginBottom: "16px", width: 800 }}
            label="Коментар..."
            multiline
            rows={4}
            value={newComment}
            onChange={handleCommentChange}
            variant="outlined"
          />
          <Button
            variant="contained"
            color="primary"
            onClick={handleCommentSubmit}
          >
            Залишити коментар
          </Button>
        </div>
      </div>
    </div>
  );
};

export default VolunteerPage;
