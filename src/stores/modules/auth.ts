import { AuthToken } from "@/types/interfaces/user";
import { defineStore } from "pinia";
import { STORAGE_AUTH_KEY } from "../mutation-type";

const InitAuth = {
  accessToken: "",
  refreshToken: "",
  expiredAt: 0,
};

export const useAuthTokenStore = defineStore(
  STORAGE_AUTH_KEY,
  () => {
    const auth = ref<AuthToken>({ ...InitAuth });

    const isLogin = () => {
      return !!getToken();
    };

    const setAuth = (authToken: AuthToken) => {
      auth.value = { ...authToken };
    };

    const clearAuth = () => {
      auth.value = { ...InitAuth };
    };

    const getToken = () => {
      return auth.value.accessToken;
    };

    return {
      isLogin,
      setAuth,
      clearAuth,
      getToken,
    };
  },
  {
    persist: true,
  },
);

export default useAuthTokenStore;
