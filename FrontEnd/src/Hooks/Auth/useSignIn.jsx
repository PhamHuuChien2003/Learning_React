import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import { LoginAPI } from "../../Services/AuthService";
import * as userLocalStorage from './user.localstore';

import {toast} from "react-toastify"

export function useSignIn() {
  const queryClient = useQueryClient();
  const navigate = useNavigate();
  const QUERY_KEY = {
    todos: "todos",
    user: "user",
  };
  const signIn = async (username, password) => {
    const res = await LoginAPI(username, password)
    if (res===undefined) toast.warning("Failed on sign in request") 
      else return res;
  }
  
  const { mutate: signInMutation, } = useMutation({
    mutationFn:  async ({username,password}) =>  signIn(username,password) ,
    onSuccess: (data) => {
      if (data === undefined) toast.warning("Please login")
        else {
          queryClient.setQueryData([QUERY_KEY.user], data);
          userLocalStorage.saveUser(data);
          navigate("/home");
          toast.success("Login Success!");
        }
    },
    onError: (error) => {
      toast.warning("Failed on sign in request");
      navigate("/")
    },
  });
  return signInMutation;
}
