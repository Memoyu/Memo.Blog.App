import { UserInfo, LoginParams, AuthToken } from "@/types/interfaces/user";
import { defineStore } from "pinia";
import { getUserInfo, login as userLogin } from "@/services/api/user";
import { STORAGE_USER_KEY } from "../mutation-type";
import useAuthTokenStore from "./auth";

const InitUserInfo = {
  userId: "",
  username: "",
  nickname: "",
  avatar: "",
  email: "",
  phoneNumber: "",
  roles: [],
};

export const useUserStore = defineStore(
  STORAGE_USER_KEY,
  () => {
    const authTokenStore = useAuthTokenStore();
    const userInfo = ref<UserInfo>({ ...InitUserInfo });

    const setInfo = (user: UserInfo) => {
      userInfo.value = { ...user };
    };
    const login = async (loginParams: LoginParams) => {
      try {
        const data = {
          accessToken:
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6Ijg3MTgxMTA5MzU2Nzg5ODEiLCJuYW1lIjoibWVtb3l1IiwiZW1haWwiOiJtbXk2MDc2QG91dGxvb2suY29tIiwiZXhwIjoxNzU0NDI1MTA0LCJpc3MiOiJtZW1veXUiLCJhdWQiOiJtZW1vLmJsb2cifQ.0bCOK-ulBIv7LAoZYYYOnGKN44rq-E6J7nJM-cVtd6w",
          refreshToken: "LrCwmrVX3S83HsoyMfyR67SJD20k38Lpb13MVcEweVc=",
          expiredAt: 1754425104990,
        };
        // TODO: 等待接口对接
        // const { data } = await userLogin(loginParams);
        authTokenStore.setAuth(data);
      } catch (error) {
        authTokenStore.clearAuth();
        throw error;
      }
    };

    const info = async () => {
      try {
        // TODO: 等待接口对接
        // const data = await getUserInfo();
        const data = {
          userId: "8718110935678981",
          username: "memoyu",
          nickname: "memoyu",
          avatar: "http://oss.blog.memoyu.com/account/avatar/-9999a82392f.png",
          email: "mmy6076@outlook.com",
          phoneNumber: "private",
          roles: ["管理", "游客"],
        };
        setInfo({ ...data });
      } catch (error) {
        authTokenStore.clearAuth();
        throw error;
      }
    };

    const logout = async () => {
      authTokenStore.clearAuth();
      setInfo({ ...InitUserInfo });
    };

    return {
      userInfo,
      info,
      login,
      logout,
    };
  },
  {
    persist: true,
  },
);

export default useUserStore;
