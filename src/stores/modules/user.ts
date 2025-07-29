import { UserInfo, LoginParams } from "@/types/interfaces/user";
import { defineStore } from "pinia";
import { clearToken, setToken } from "@/utils/auth";
import { getUserInfo, login as userLogin } from "@/services/api/user";
import { STORAGE_USER_KEY } from "../mutation-type";

const InitUserInfo = {
  userId: "",
  username: "",
  nickname: "",
  avatar: "",
  email: "",
  phoneNumber: "",
};

export const useUserStore = defineStore(
  STORAGE_USER_KEY,
  () => {
    const userInfo = ref<UserInfo>({ ...InitUserInfo });

    const setInfo = (user: UserInfo) => {
      userInfo.value = { ...user };
    };
    const login = async (loginParams: LoginParams) => {
      try {
        const { data } = await userLogin(loginParams);
        setToken(data.token);
      } catch (error) {
        clearToken();
        throw error;
      }
    };

    const info = async () => {
      try {
        const data = await getUserInfo();
        setInfo(data);
      } catch (error) {
        clearToken();
        throw error;
      }
    };

    const logout = async () => {
      clearToken();
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
