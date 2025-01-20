import axiosInstance from './axiosInstance';
import endpoints from './endpoints';

export const search = async (query) => {
  try {
    const response = await axiosInstance.get(endpoints.search, { query });
    return response.data;
  } catch (error) {
    throw error;
  }
};