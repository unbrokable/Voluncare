import { api } from "../api/api";

const Login = ({ email, password }) => {
  return api.post(
    "tut endpoint",
    { email: email, password: password },
    { headers: { bubu: "bubu" } }
  );
};
