import { PaginationRequest } from "./common";

export enum UserIdentityType {
  Password = 0,
  WeiXin = 1,
  Qq = 2,
  GitHub = 3,
  Gitee = 4,
}

export enum UserRoleType {
  Create = 0,
  Init = 1,
}

export interface UserLogin {
  userId: string;
  username: string;
  accessToken: string;
  refreshToken: string;
  expiredAt: number;
}

export interface UserInfo {
  userId: string;
  username: string;
  nickname: string;
  avatar: string;
  email: string;
  phoneNumber: string;
  roles: UserRole[];
}

export interface LoginParams {
  username: string;
  password: string;
}

export interface LoginRes {
  accessToken: string; // 访问token
  refreshToken: string; // 刷新token
  userId: string; // 用户Id
  username: string; // 用户名
  expiredAt: number; // token过期时间
}

export interface AuthToken {
  accessToken: string; // 访问token
  refreshToken: string; // 刷新token
  expiredAt: number; // token过期时间
}

export interface UserPageRequest extends PaginationRequest {
  userId?: string;
  username?: string;
  nickname?: string;
  email?: string;
  phoneNumber?: string;
  userIdentityType?: UserIdentityType;
  roles?: Array<string>;
}

export interface UserPageItem {
  userId: string;
  username: string;
  nickname: string;
  avatar: string;
  email: string;
  phoneNumber: string;
  userIdentityType: UserIdentityType;
  roles: Array<UserRole>;
  lastLoginTime: Date;
  createTime: Date;
}

export interface UserRole {
  roleId: string; // 角色Id
  name: string;
  type: UserRoleType;
  description: string;
}

export interface UserPermission {
  permissionId: string; // 权限Id
  module: string;
  moduleName: string;
  name: string;
  signature: string;
}

export interface UserRoleWithPermission {
  roleId: string; // 角色Id
  name: string;
  type: UserRoleType;
  description: string;
  permissions: Array<UserPermission>;
}

export interface PermissionGroup {
  module: string;
  moduleName: string;
  permissions: Array<PermissionWithCheck>;
}

export interface PermissionWithCheck extends UserPermission {
  checked: boolean;
}
