import axios from 'axios';

// 自动检测当前环境，决定 API 地址
const API_URL =
  window.location.hostname === 'localhost'
    ? 'http://localhost:5001'  // 🖥️ 浏览器访问后端时
    : 'http://backend:5001';    // 🐳 Docker 内部前端访问后端时

console.log("Final API Base URL:", API_URL);

const axiosInstance = axios.create({
  baseURL: API_URL,
  timeout: 10000,
  headers: {
    'Content-Type': 'application/json',
  },
});

export default axiosInstance;