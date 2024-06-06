import axios from "axios";
import { handleError } from "../Helpers/ErrorHandler.jsx";

const api = "http://localhost:5149/api/";

export const commentPostAPI = async (
  title,
  content,
  symbol
) => {
  try {
    const data = await axios.post(api + `${symbol}`, {
      title: title,
      content: content,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const postGetAPI = async () => {
  try {
    const data = await axios.get(api + ``);
    return data;
  } catch (error) {
    handleError(error);
  }
};