import { PaginationResult } from "@/types/interfaces";
import {
  LoginParams,
  LoginRes,
  UserInfo,
  UserPageItem,
  UserPageRequest,
} from "@/types/interfaces/user";
import Request from "@/utils/request";

export default {
  login(data: LoginParams) {
    return Request.post<LoginRes>("token/generate", data);
  },

  refreshToken(refreshToken: string): Promise<any> {
    return Request.get<LoginRes>("token/refresh", {
      headers: { "refresh-token": refreshToken },
    });
  },

  getUserInfo(id?: string) {
    return Request.get<UserInfo>("user/get", { params: { userId: id } });
  },

  userPage(request: UserPageRequest) {
    return Request.get<PaginationResult<UserPageItem>>("user/page", {
      params: request,
    });
  },
};
