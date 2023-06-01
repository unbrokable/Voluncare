import { api } from "../api/api";

export const login = ({
  username,
  password,
}: {
  username: string;
  password: string;
}) => {
  return api.post(
    "User/login",
    { userName: username, password: password },
    { headers: { "Content-Type": "application/json" } }
  );
};

export const registration = ({
  email,
  password,
  role,
  username,
}: {
  email: string;
  password: string;
  role: number;
  username: string;
}) => {
  return api.post(
    "User/register",
    {
      email: email,
      password: password,
      apllicationUserType: role,
      userName: username,
    },
    { headers: { "Content-Type": "application/json" } }
  );
};
