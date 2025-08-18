import { useAuthTokenStore } from "@/stores";
import type { AxiosError, InternalAxiosRequestConfig } from "axios";
import axios from "axios";
import { showNotify } from "vant";

const authTokenStore = useAuthTokenStore();

// 创建 axios 实例
const request = axios.create({
  // API 请求的默认前缀
  baseURL: import.meta.env.VITE_APP_API_BASE_URL,
  timeout: 6000, // 请求超时时间
});

export type RequestError = AxiosError<{
  message?: string;
  result?: any;
  errorMessage?: string;
}>;

// 异常拦截处理器
function errorHandler(error: RequestError): Promise<any> {
  if (error.response) {
    const { data = {}, status, statusText } = error.response;
    // 403 无权限
    if (status === 403) {
      showNotify({
        type: "danger",
        message: (data && data.message) || statusText,
      });
    }
    // 401 未登录/未授权
    if (status === 401 && data.result && data.result.isLogin) {
      showNotify({
        type: "danger",
        message: "Authorization verification failed",
      });
      // 如果你需要直接跳转登录页面
      // location.replace(loginRoutePath)
    }
  }
  return Promise.reject(error);
}

// 请求拦截器
function requestHandler(
  config: InternalAxiosRequestConfig,
): InternalAxiosRequestConfig | Promise<InternalAxiosRequestConfig> {
  const token = authTokenStore.getToken();
  // 如果 token 存在
  // 让每个请求携带自定义 token, 请根据实际情况修改
  if (token) config.headers["Authorization"] = token;

  return config;
}

// Add a request interceptor
request.interceptors.request.use(requestHandler, errorHandler);

// 响应拦截器
function responseHandler(response: { data: any }) {
  return response.data;
}

// Add a response interceptor
request.interceptors.response.use(responseHandler, errorHandler);

export default request;
