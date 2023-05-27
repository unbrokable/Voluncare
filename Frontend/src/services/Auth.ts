import { api } from "../api/api";

const Login = ({ email, password }: { email: string; password: string }) => {
  return api.post(
    "tut endpoint",
    { email: email, password: password },
    { headers: { bubu: "bubu" } }
  );
};
