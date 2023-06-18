import { api } from "../api/api";

export const getUserInfo = ({
  userId,
  token,
}: {
  token: string;
  userId: string;
}) => {
  return api.post(
    "Volunteer/getInfo",
    { id: userId },
    {
      headers: { Authorization: `Bearer ${token}` },
    }
  );
};
