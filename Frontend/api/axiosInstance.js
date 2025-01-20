//Axios配置文件
import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'http://localhost:5290', // 替换为你的 API 根路径
  timeout: 10000, // 设置请求超时时间
  headers: {
    'Content-Type': 'application/json',
  },
});

// 请求拦截器

// 响应拦截器

export default axiosInstance;