import axios from "axios";

export const URL = "https://voluncare-api.azurewebsites.net/api/";

export const api = axios.create({
  baseURL: URL,
});
