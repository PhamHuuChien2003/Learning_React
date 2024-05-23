import { useMutation, useQueryClient } from '@tanstack/react-query';
import { useNavigate } from 'react-router-dom';
import { QUERY_KEY } from '../constants/queryKeys';
import { RegisterAPI } from '../../Services/AuthService';


export function useSignUp(){
  const queryClient = useQueryClient();
  const navigate = useNavigate();
  const { mutate: signUpMutation } = useMutation(
    ({
      email,
      password
    }) => RegisterAPI(email, password), {
    onSuccess: (data) => {
      queryClient.setQueryData([QUERY_KEY.user], data);
      navigate('/');
    },
    onError: () => {<>error</>},
  });
  return signUpMutation
}