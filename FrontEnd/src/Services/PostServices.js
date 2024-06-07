import axios from "axios";
import { handleError } from "../Helpers/ErrorHandler.jsx";

const api = "http://localhost:5149/api/post/";

export const postGetAPI = async (postPageParam) => {
  try {
    const res = await axios.post(api + `?SortBy=posttime&IsDecsending=true&PageSize=5`);
    console.log("datapostPage",res);
    return res
  } catch (error) {
    handleError(error);
  }
};

// export const postGetAPI = async () => {
//   try {
//     const data = await axios.get(api + ``);
//     return data;
//   } catch (error) {
//     handleError(error);
//   }
// };