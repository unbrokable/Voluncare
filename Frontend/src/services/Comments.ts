import { api } from "../api/api";

export const postComment = ({
  userId,
  receiverId,
  token,
  text,
  helpRequestId,
}: {
  token: string;
  userId: string;
  text: string;
  receiverId?: string;
  helpRequestId?: string;
}) => {
  return api.post(
    "Comment/create",
    { userId, text, receiverId, helpRequestId },
    {
      headers: { Authorization: `Bearer ${token}` },
    }
  );
};

export const getComments = ({
  receiverId,
  token,
  helpRequestId,
}: {
  token: string;
  receiverId?: string;
  helpRequestId?: string;
}) => {
  return api.post(
    "Comment/get",
    { receiverId, helpRequestId },
    {
      headers: { Authorization: `Bearer ${token}` },
    }
  );
};
