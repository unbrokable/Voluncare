import { api } from "../api/api";

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

// takenOrganizationId,
// takenVolunteerId,
// takenOrganizationId: string;
// takenVolunteerId: string;
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
