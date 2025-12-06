import { PaginationRequest } from "./common";

export interface FriendPageRequest extends PaginationRequest {
  nickname?: string; // 友链名称
  description?: string;
  site?: string;
}

export interface FriendPageItem {
  friendId: string; // 友链Id
  nickname: string; // 友链名称
  description: string;
  site: string;
  avatar: string;
  showable: boolean;
  views: number;
  createTime: Date;
}
