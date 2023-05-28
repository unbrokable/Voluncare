import axios from "axios";

export const URL = "";

export const api = axios.create({
  baseURL: URL,
});
