export interface Moment {
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
