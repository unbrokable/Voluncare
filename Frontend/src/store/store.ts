import { atom } from "recoil";

export const tokenState = atom({
  key: "token", // unique ID (with respect to other atoms/selectors)
  default: "", // default value (aka initial value)
});

export const userState = atom({
  key: "user", // unique ID (with respect to other atoms/selectors)
  default: {}, // default value (aka initial value)
});
