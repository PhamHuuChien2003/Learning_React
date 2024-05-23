import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import { LoginAPI } from "../../Services/AuthService";

export function useSignIn() {

  debugger
  const queryClient = useQueryClient();
  const navigate = useNavigate();
  const QUERY_KEY = {
    todos: "todos",
    user: "user",
  };
  const { mutate: signInMutation } = useMutation({
    mutationFn:  async ({username,password}) =>  LoginAPI(username,password) ,
    onSuccess: (data) => {
      queryClient.setQueryData([QUERY_KEY.user], data);
      navigate("/home");
    },
    onError: () => {<>error</>},
  });
  debugger




  return signInMutation;
}
