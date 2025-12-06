import { PageEnum, ResponseCode } from "@/common/enums";
import { useAuthTokenStore } from "@/stores";
import type {
  AxiosError,
  AxiosInstance,
  AxiosRequestConfig,
  AxiosResponse,
  InternalAxiosRequestConfig,
} from "axios";
import axios from "axios";
import { showNotify } from "vant";
import router from "@/router";

type ResponseResult<T> = {
  isSuccess: boolean; // 是否成功
  code: ResponseCode; // 响应编码
  data?: T; // 响应数据
  message: string; // 响应消息
};

export class Request {
  isRefreshing = false;
  requestQueue: (() => void)[] = [];

  // axios 实例
  instance: AxiosInstance;
  // 基础配置，url和超时时间
  baseConfig: AxiosRequestConfig = {
    baseURL: import.meta.env.VITE_APP_API_BASE_URL + "api/admin/",
    timeout: 10_000,
  };

  constructor(config: AxiosRequestConfig) {
    // 使用axios.create创建axios实例
    this.instance = axios.create(Object.assign(this.baseConfig, config));

    // 请求拦截器
    this.instance.interceptors.request.use(
      (config) => {
        const token = useAuthTokenStore().getToken();
        if (token) config.headers.Authorization = `Bearer ${token}`;

        return config;
      },
      (error) => {
        // 对请求错误做些什么
        return Promise.reject(error);
      },
    );

    // 响应拦截器
    this.instance.interceptors.response.use(
      (response) => {
        // 2xx 范围内的状态码都会触发该函数。
        // 对响应数据做点什么
        // console.log('响应success', response.data);
        var res = response.data as ResponseResult<any>;
        if (res.code != ResponseCode.SUCCESS || !res.data) {
          showNotify({
            type: "danger",
            message: res.message,
          });
          throw new Error(res.message);
        }
        return res.data;
      },
      async (error) => {
        const { response } = error;
        // console.log('响应error', error);
        if (response && response.data) {
          const { code, message } = response.data;
          if (code === ResponseCode.TOKEN_EXPIRED) {
            const authTokenStore = useAuthTokenStore();
            // token过期，刷新token
            if (!this.isRefreshing) {
              this.isRefreshing = true;
              return new Promise((resolve) => {
                authTokenStore
                  .refreshAuth()
                  .then(() => {
                    this.requestQueue.forEach((request) => request());
                    this.requestQueue = []; // 重新请求完清空
                    resolve(this.instance.request(response.config));
                  })
                  .catch((error) => {
                    console.log("刷新token异常", error);
                    // 重新登陆
                    router.replace(PageEnum.LOGIN);
                  })
                  .finally(() => {
                    this.isRefreshing = false;
                  });
              });
            } else {
              return new Promise((resolve) => {
                // 用函数形式将 resolve 存入，等待刷新后再执行
                this.requestQueue.push(() => {
                  resolve(this.instance.request(response.config));
                });
              });
            }
          } else if (
            code === ResponseCode.TOKEN_INVALIDATION ||
            code === ResponseCode.AUTHENTICATION_FAILURE
          ) {
            // token无效，重新登陆
            router.replace(PageEnum.LOGIN);
          }

          showNotify({
            type: "danger",
            message: message,
          });
        }

        showNotify({
          type: "danger",
          message: "服务暂不可用，请稍后再试！",
        });
        return Promise.reject(error);
      },
    );
  }

  // 定义请求方法
  public request(config: AxiosRequestConfig): Promise<AxiosResponse> {
    return this.instance.request(config);
  }

  public get<T = any>(url: string, config?: AxiosRequestConfig) {
    return this.instance.get<T, T>(url, config);
  }

  public post<T = any>(url: string, data?: any, config?: AxiosRequestConfig) {
    return this.instance.post<T, T>(url, data, config);
  }

  public put<T = any>(url: string, data?: any, config?: AxiosRequestConfig) {
    return this.instance.put<T, T>(url, data, config);
  }

  public delete<T = any>(url: string, config?: AxiosRequestConfig) {
    return this.instance.delete<T, T>(url, config);
  }
}

export default new Request({});
