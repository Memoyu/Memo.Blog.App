import { MetricItem, PaginationRequest } from "./common";

export enum ArticleStatus {
  Draft = 0,
  Published = 1,
  Offline = 2,
}

export interface ArticleRankingItem {
  articleId: string;
  banner: string;
  title: string;
  comments: number;
  likes: number;
  views: number;
}

export interface ArticlePageRequest extends PaginationRequest {
  title?: string;
  categoryId?: string;
  tagIds?: Array<string>;
  status?: ArticleStatus;
}

export interface ArticlePageItem {
  articleId: string; // 文章Id
  category: ArticleCategory; // 分类
  title: string;
  description: string;
  banner: string;
  tags: Array<ArticleTag>;
  status: ArticleStatus;
  comments: number;
  views: number;
  likes: number;
  isTop: boolean;
  commentable: boolean;
  publicable: boolean;
  createTime: Date;
  updateTime?: Date;
  publishTime?: Date;
}

export interface ArticleSummary {
  articles: number;
  comments: number;
  views: number;
  weekArticles: Array<MetricItem>;
  weekComments: Array<MetricItem>;
  weekViews: Array<MetricItem>;
}

export interface Article {
  articleId: string;
  banner: string;
  title: string;
  comments: number;
  likes: number;
  views: number;
  updateDateTime: Date;
}

export interface ArticleTag {
  tagId: string;
  name: string;
  articles: number;
}

export interface ArticleCategory {
  categoryId: string; // 分类Id
  name: string; // 分类名称
  articles: number;
}
