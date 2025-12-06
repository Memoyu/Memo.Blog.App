import { UserInfo, LoginParams } from "@/types/interfaces/user";
import { defineStore } from "pinia";
import api from "@/services/api";
import { STORAGE_USER_KEY } from "../mutation-type";
import { useAuthTokenStore } from "@/stores";

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
        const data = await api.login(loginParams);
        authTokenStore.setAuth({
          accessToken: data.accessToken,
          refreshToken: data.refreshToken,
          expiredAt: data.expiredAt,
        });
      } catch (error) {
        authTokenStore.clearAuth();
        throw error;
      }
    };

    const info = async () => {
      try {
        const data = await api.getUserInfo();
        setInfo(data);
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
