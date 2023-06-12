import { Pagination, Tab, Tabs } from "@mui/material";
import React, { useEffect, useState } from "react";
import { getHelpRequests, getTotalCount } from "../../services/HelpRequests";
import { useRecoilState } from "recoil";
import { helpRequestState, tokenState } from "../../store/store";
import moment from "moment";
import { AccessTime, Person } from "@mui/icons-material";

interface VolunteerMainProps {}

const VolunteerMain: React.FC<VolunteerMainProps> = () => {
  const [activeTab, setActiveTab] = useState(0);

  const [token, setToken] = useRecoilState(tokenState);

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
        <Tab label="Організації" style={{ fontWeight: "600" }} />
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
              requester: string;
              status: number;
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
                      {request.userName}
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
            )
          )}
          <Pagination
            count={Math.ceil(totalCount / 5)}
            onChange={(event, page) =>
              getHelpRequests({ page: page, count: 5, token: token }).then(
                (data) => setHelpRequests(data.data)
              )
            }
            showFirstButton
            showLastButton
          />
        </div>
      )}
      {activeTab === 1 && <div style={{ padding: 20 }}>GOGO</div>}
      {activeTab === 2 && <div style={{ padding: 20 }}>LALA</div>}
    </div>
  );
};

export default VolunteerMain;
