import { api } from "../api/api";

export const updateProfile = ({
  id,
  email,
  avatarImage,
  phoneNumber,
}: {
  id: string;
  email: string;
  avatarImage: string;
  phoneNumber: string;
}) => {
  return api.post(
    "User/update",
    {
      id,
      email,
      avatarImage,
      phoneNumber,
    },
    { headers: { "Content-Type": "application/json" } }
  );
};

export const uploadAvatarImage = (file: any) => {
  const formData = new FormData();
  formData.append("file", file);

  return api.post("User/uploadImage", formData, {
    headers: {
      "Content-Type": "multipart/form-data",
    },
  });
};
