import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import { useUser } from "./useUser";

export function useLogIn(email, password) {
  const queryClient = useQueryClient();
  const navigate = useNavigate();
  const QUERY_KEY = {
    todos: "todos",
    user: "user",
  };
  const getDataUser = useUser(email, password)
  const { mutate: logInMutation } = useMutation({
    mutationFn: getDataUser,
    onSuccess: (data) => {
      queryClient.setQueryData([QUERY_KEY.user], data);
      navigate("/home");
    },
    onError: () => {<>error</>},
  });

  return logInMutation;
}
