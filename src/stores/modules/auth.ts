import { AuthToken } from "@/types/interfaces/user";
import { defineStore } from "pinia";
import { STORAGE_AUTH_KEY } from "../mutation-type";
import api from "@/services/api";

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

    const refreshAuth = async () => {
      try {
        const { data } = await api.refreshToken(auth.value.refreshToken);
        setAuth(data);
      } catch (error) {
        clearAuth();
        throw error;
      }
    };

    return {
      auth,
      isLogin,
      setAuth,
      clearAuth,
      getToken,
      refreshAuth,
    };
  },
  {
    persist: true,
  },
);

export default useAuthTokenStore;
