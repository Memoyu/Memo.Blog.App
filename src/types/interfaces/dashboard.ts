import { MetricItem } from "./common";

export interface SummaryStatistics {
  weekArticles: number;
  articles: number;
  moments: number;
  friends: number;
}

export interface UniqueVisitorStatistics {
  todayUniqueVisitors: number;
  weekUniqueVisitors: Array<MetricItem>;
  uniqueVisitors: number;
}

export interface PageVisitorStatistics {
  todayPageVisitors: number;
  weekPageVisitors: Array<MetricItem>;
  pageVisitors: number;
}

export interface CommentStatistics {
  todayComments: number;
  weekComments: Array<MetricItem>;
  comments: number;
}

export interface DashboardStatistics {
  summary: SummaryStatistics;
  uniqueVisitor: UniqueVisitorStatistics;
  pageVisitor: PageVisitorStatistics;
  comment: CommentStatistics;
}
