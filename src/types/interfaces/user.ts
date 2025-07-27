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
}

export interface LoginParams {
  username: string;
  password: string;
}
