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

export interface UserRole {
  description: string;
  name: string;
  roleId: string;
  type: number;
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
