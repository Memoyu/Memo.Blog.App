import { PaginationResult } from "@/types/interfaces";
import {
  LoginParams,
  LoginRes,
  PermissionGroupItem,
  PermissionListItem,
  UserInfo,
  UserPageItem,
  UserPageRequest,
  UserRole,
  UserRoleWithPermission,
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

  roleList(name?: string) {
    return Request.get<Array<UserRole>>("role/list", { params: { name } });
  },

  roleGet(id: string) {
    return Request.get<UserRoleWithPermission>("role/get", {
      params: { roleId: id },
    });
  },

  permissionGroup(name?: string) {
    return Request.get<Array<PermissionGroupItem>>("permission/group", {
      params: { name },
    });
  },

  permissionList(name?: string, signature?: string) {
    return Request.get<Array<PermissionListItem>>("permission/list", {
      params: { name, signature },
    });
  },
};
