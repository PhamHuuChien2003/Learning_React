
import { useEffect } from 'react';
import * as Services from '../../Services/AuthService';
import * as userLocalStorage from './user.localstore';
import { useQuery } from '@tanstack/react-query';

const QUERY_KEY = {
  todos: 'todos',
  user: 'user',
};

export function useUser(username, password)  {

  const logIn = async (username, password) => {
    const res = await Services.LoginAPI(username, password)
    return res.data;
  }

  const { data: user, error } = useQuery({
    queryKey:[QUERY_KEY.user],
    queryFn:(username, password) => logIn(username, password), 
    refetchOnMount: false,
    refetchOnWindowFocus: false,
    refetchOnReconnect: false,
    initialData: userLocalStorage.getUser,
  });
  useEffect(() => {
    if (!user) userLocalStorage.removeUser();
    else userLocalStorage.saveUser(user);
  }, [user]);
  if(error) {userLocalStorage.removeUser();return (<>error;</>)};

  return (
    user.data
  )
}