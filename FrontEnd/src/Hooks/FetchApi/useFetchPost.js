
import { useEffect } from 'react';
import * as Services from '../../Services/services';
import * as userLocalStorage from './user.localstore';
import { useQuery } from '@tanstack/react-query';

const QUERY_KEY = {
    post: 'todos',
};

export function useFetchPost()  {

  
  const { data: post, error } = useQuery({
    queryKey:[QUERY_KEY.post],
    queryFn:() => Services.postGetAPI(), 
    refetchOnMount: false,
    refetchOnWindowFocus: false,
    refetchOnReconnect: false,
    initialData: userLocalStorage.getUser,
  });
  useEffect(() => {
    if (!post) userLocalStorage.removeUser();
    else userLocalStorage.saveUser(post);
  }, [post]);
  if(error) {userLocalStorage.removeUser();return (<>error;</>)};

  return (
    post.data
  )
}