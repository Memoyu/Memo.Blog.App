import { PaginationRequest } from "./common";

export interface MomentPageRequest extends PaginationRequest {
  tags?: Array<string>;
  content?: string;
  dateBegin?: string;
  dateEnd?: string;
}

export interface MomentPageItem {
  momentId: string;
  tags: string[];
  content: string;
  likes: number;
  comments: number;
  commentable: boolean;
  createTime: Date;
  isLike: boolean;
  announcer: MomentAnnouncer;
}

export interface MomentAnnouncer {
  userId: string;
  nickname: string;
  avatar: string;
}
