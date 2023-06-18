import { atom } from "recoil";

export const tokenState = atom({
  key: "token", // unique ID (with respect to other atoms/selectors)
  default: "", // default value (aka initial value)
});

export const userState = atom({
  key: "user", // unique ID (with respect to other atoms/selectors)
  default: {
    id: "",
    userName: "",
    email: "",
    apllicationUserType: 0,
    avatarImage: "",
    phoneNumber: "",
  }, // default value (aka initial value)
});

export const helpRequestState = atom({
  key: "helpRequest",
  default: { list: [], count: 0 },
});

export const acceptedHelpRequestState = atom({
  key: "acceptedHelpRequest",
  default: { list: [], count: 0 },
});

export const userHelpRequestsState = atom({
  key: "userHelpRequests",
  default: { list: [], count: 0 },
});

export const volunteerState = atom({
  key: "volunteer",
  default: {
    result: {
      id: "",
      avatarImage: "",
      phoneNumber: "",
      userName: "",
      averageRating: 0,
      trustLevel: 0,
    },
    comments: [],
  },
});

export const commentsState = atom({
  key: "comments",
  default: [],
});
