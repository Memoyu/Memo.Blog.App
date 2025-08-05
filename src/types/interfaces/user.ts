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
  roles: string[];
}

export interface LoginParams {
  username: string;
  password: string;
}

export interface AuthToken {
  accessToken: string; // 访问token
  refreshToken: string; // 刷新token
  expiredAt: number; // token过期时间
}
