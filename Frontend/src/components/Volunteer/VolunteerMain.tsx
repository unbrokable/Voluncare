import { Button, Pagination, Tab, Tabs } from "@mui/material";
import React, { useEffect, useState } from "react";
import {
  assignVolunteer,
  completeHelpRequests,
  getAcceptedHelpRequests,
  getHelpRequests,
  getTotalCount,
} from "../../services/HelpRequests";
import { useRecoilState } from "recoil";
import {
  acceptedHelpRequestState,
  helpRequestState,
  tokenState,
  userState,
} from "../../store/store";
import moment from "moment";
import { AccessTime, Person } from "@mui/icons-material";

interface VolunteerMainProps {}

const VolunteerMain: React.FC<VolunteerMainProps> = () => {
  const [activeTab, setActiveTab] = useState(0);

  const [token, setToken] = useRecoilState(tokenState);
  const [user, setUser] = useRecoilState(userState);
  const [acceptedHelpRequest, setAcceptedHelpRequest] = useRecoilState(
    acceptedHelpRequestState
  );

  const [accept, setAccept] = useState("");
  const [page, setPage] = useState(1);
  const [acceptedPage, setAcceptedPage] = useState(1);

  const [totalCount, setTotalCount] = useState(0);

  const handleTabChange = (event: any, newValue: number) => {
    setActiveTab(newValue);
  };

  const [helpRequests, setHelpRequests] = useRecoilState(helpRequestState);

  useEffect(() => {
    getHelpRequests({ page: 1, count: 5, token: token }).then((data) =>
      setHelpRequests(data.data)
    );
    getTotalCount({ token: token }).then((data) =>
      setTotalCount(data.data.count)
    );
    getAcceptedHelpRequests({
      page: 1,
      count: 5,
      token: token,
      volunteerId: user?.id,
    }).then((data) => setAcceptedHelpRequest(data.data));
  }, []);

  return (
    <div style={{ width: "100%", height: "91.5%", backgroundColor: "white" }}>
      <Tabs
        value={activeTab}
        onChange={handleTabChange}
        textColor="secondary"
        indicatorColor="secondary"
        variant="fullWidth"
      >
        <Tab label="Усі запити" style={{ fontWeight: "600" }} />
        <Tab label="Ваші прийняті запити" style={{ fontWeight: "600" }} />
      </Tabs>
      {activeTab === 0 && (
        <div style={{ padding: 40 }}>
          {helpRequests?.list.map(
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
                  minWidth: 275,
                  backgroundColor: "#8F85DF",
                  padding: 16,
                  boxShadow: "0 2px 4px rgba(0, 0, 0, 0.1)",
                  marginBottom: 20,
                }}
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
                          {`${request.title}`}
                        </text>
                      </div>
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
                          {`${request?.userName}`}
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
                    <div style={{ width: 1000 }}>
                      <text
                        style={{
                          marginRight: 12,
                          fontWeight: 400,
                          fontSize: 18,
                          color: "white",
                        }}
                      >
                        {`${request.description}`}
                      </text>
                    </div>
                  </div>
                  {accept !== request?.helpRequestId && (
                    <Button
                      onClick={() => setAccept(request?.helpRequestId)}
                      variant="contained"
                      disabled={!!request?.takenVolunteerId}
                      style={
                        !!request?.takenVolunteerId
                          ? {
                              width: 200,
                              marginLeft: 140,
                              marginRight: 50,
                              backgroundColor: "lightgray",
                            }
                          : {
                              width: 200,
                              marginLeft: 0,
                              marginRight: 50,
                              backgroundColor: "#EFC7C2",
                            }
                      }
                    >
                      Прийняти заявку
                    </Button>
                  )}

                  {accept === request?.helpRequestId && (
                    <div style={{ marginRight: 50 }}>
                      <Button
                        onClick={() => {
                          assignVolunteer({
                            token: token,
                            requestId: request?.helpRequestId,
                            takenVolunteerId: user?.id,
                          }).then(() => {
                            getHelpRequests({
                              page: page,
                              count: 5,
                              token: token,
                            }).then((data) => {
                              setHelpRequests(data.data);
                              setAccept("");
                            });

                            getAcceptedHelpRequests({
                              page: acceptedPage,
                              count: 5,
                              token: token,
                              volunteerId: user?.id,
                            }).then((data) =>
                              setAcceptedHelpRequest(data.data)
                            );
                          });
                        }}
                        variant="contained"
                        color="success"
                        style={{
                          width: 200,
                        }}
                      >
                        Прийняти
                      </Button>
                      <Button
                        onClick={() => setAccept("")}
                        variant="contained"
                        color="error"
                        style={{
                          width: 200,
                          marginLeft: 30,
                        }}
                      >
                        Відмінити
                      </Button>
                    </div>
                  )}
                </div>
              </div>
            )
          )}
          <Pagination
            count={Math.ceil(totalCount / 5)}
            onChange={(event, page) => {
              getHelpRequests({ page: page, count: 5, token: token }).then(
                (data) => setHelpRequests(data.data)
              );
              setPage(page);
            }}
            showFirstButton
            showLastButton
          />
        </div>
      )}
      {activeTab === 1 && (
        <div style={{ padding: 20 }}>
          {acceptedHelpRequest?.list.map(
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
                  request.status !== 3
                    ? {
                        minWidth: 275,
                        backgroundColor: "#8F85DF",
                        padding: 16,
                        boxShadow: "0 2px 4px rgba(0, 0, 0, 0.1)",
                        marginBottom: 20,
                      }
                    : {
                        minWidth: 275,
                        backgroundColor: "lightgray",
                        padding: 16,
                        boxShadow: "0 2px 4px rgba(0, 0, 0, 0.1)",
                        marginBottom: 20,
                      }
                }
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
                        style={{ marginLeft: 4, fontSize: 16, color: "white" }}
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
                    width: 1000,
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
                {accept !== request?.helpRequestId && (
                  <Button
                    disabled={request.status === 3}
                    onClick={() => {
                      completeHelpRequests({
                        token,
                        requestId: request.helpRequestId,
                      }).then(() =>
                        getAcceptedHelpRequests({
                          page: 1,
                          count: 5,
                          token: token,
                          volunteerId: user?.id,
                        }).then((data) => setAcceptedHelpRequest(data.data))
                      );
                    }}
                    variant="contained"
                    style={{
                      width: 200,
                      marginLeft: 1540,
                      top: -46,
                      backgroundColor: "#EFC7C2",
                    }}
                  >
                    Завершити
                  </Button>
                )}
              </div>
            )
          )}
          <Pagination
            count={Math.ceil(totalCount / 5)}
            onChange={(event, page) => {
              getAcceptedHelpRequests({
                page: page,
                count: 5,
                token: token,
                volunteerId: user?.id,
              }).then((data) => setAcceptedHelpRequest(data.data));
              setPage(page);
            }}
            showFirstButton
            showLastButton
          />
        </div>
      )}
    </div>
  );
};

export default VolunteerMain;
