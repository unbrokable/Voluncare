import { api } from "../api/api";
//Unassigned
export const getHelpRequests = ({
  page,
  count,
  token,
}: {
  page: number;
  count: number;
  token: string;
}) => {
  return api.post(
    "HelpRequest/getList",
    {
      page,
      count,
    },
    {
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    }
  );
};

export const createHelpRequests = ({
  userId,
  title,
  description,
  contactNumber,
  token,
}: {
  userId: string;
  title: string;
  description: string;
  contactNumber: string;
  token: string;
}) => {
  return api.post(
    "HelpRequest/create",
    {
      userId,
      title,
      description,
      contactNumber,
    },
    {
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    }
  );
};

export const getTotalCount = ({ token }: { token: string }) => {
  return api.get("HelpRequest/totalCount", {
    headers: { Authorization: `Bearer ${token}` },
  });
};

export const assignVolunteer = ({
  token,
  takenVolunteerId,
  requestId,
}: {
  token: string;
  takenVolunteerId: string;
  requestId: string;
}) => {
  return api.post(
    "HelpRequest/assingVolunteer",
    { requestId, takenVolunteerId },
    {
      headers: { Authorization: `Bearer ${token}` },
    }
  );
};

export const getAcceptedHelpRequests = ({
  count,
  page,
  token,
  volunteerId,
}: {
  count: number;
  page: number;
  token: string;
  volunteerId: string;
}) => {
  return api.post(
    "Volunteer/showAcceptedHR",
    { count, page, volunteerId },
    {
      headers: { Authorization: `Bearer ${token}` },
    }
  );
};

export const getUserHelpRequests = ({
  count,
  page,
  token,
  userId,
}: {
  count: number;
  page: number;
  token: string;
  userId: string;
}) => {
  return api.post(
    "HelpRequest/userRequests",
    { count, page, userId },
    {
      headers: { Authorization: `Bearer ${token}` },
    }
  );
};

export const deleteHelpRequests = ({
  requestId,
  token,
}: {
  token: string;
  requestId: string;
}) => {
  return api.post(
    "HelpRequest/remove",
    { requestId },
    {
      headers: { Authorization: `Bearer ${token}` },
    }
  );
};

export const completeHelpRequests = ({
  requestId,
  token,
}: {
  token: string;
  requestId: string;
}) => {
  return api.post(
    "HelpRequest/complete",
    { requestId },
    {
      headers: { Authorization: `Bearer ${token}` },
    }
  );
};
