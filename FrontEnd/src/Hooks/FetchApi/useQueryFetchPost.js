import React from 'react';

import * as Services from '../../Services/PostServices';
import { useQuery } from '@tanstack/react-query';

const QUERY_KEY = {
    post: 'fetchpost',
};

export function useQueryFetchPost(postPageParam)  {

  const { data: post, error,isLoading} = useQuery({
    queryKey:[QUERY_KEY.post,postPageParam],
    queryFn:() => Services.postGetAPI(postPageParam), 
    refetchOnMount: false,
    refetchOnWindowFocus: false,
    refetchOnReconnect: false,
  });
  if(error) {return (<>error</>)};
  if(isLoading) {return (<>Loading...</>)};
  return post;
}