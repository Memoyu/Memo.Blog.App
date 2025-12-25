import { PaginationRequest } from "./common";

export enum SystemLogLevel {
  Debug = 1,
  Info = 2,
  Warning = 3,
  Error = 4,
  Fatal = 5,
}

export enum VisitLogBehavior {
  Unknown = -1,
  Home = 0,
  Article = 1,
  ArticleDetail = 11,
  Labs = 2,
  Moment = 3,
  About = 4,
}

export interface SystemLogPageRequest extends PaginationRequest {
  id?: string;
  level?: SystemLogLevel;
  message?: string;
  source?: string;
  requestParamterName?: string;
  requestParamterValue?: string;
  requestId?: string;
  requestPath?: string;
  dateBegin?: string;
  dateEnd?: string;
}

export interface SystemLogPageItem {
  id: string;
  level: SystemLogLevel;
  message: string;
  source: string;
  request: string;
  requestId: string;
  requestPath: string;
  exMessage: string;
  time: Date;
}

export interface VisitLogPageRequest extends PaginationRequest {
  visitId?: string; // 访问日志Id
  visitorId?: string; // 访客Id
  behavior?: VisitLogBehavior;
  behaviorName?: string;
  visitedId?: number; // 被访问信息Id（文章Id、动态Id等）
  path?: string;
  ip?: string;
  country?: string;
  region?: string;
  province?: string;
  city?: string;
  isp?: string;
  os?: string;
  browser?: string;
  dateBegin?: string;
  dateEnd?: string;
}

export interface VisitLogPageItem {
  visitId: string; // 访问日志Id
  visitorId: string; // 访客Id
  behavior: VisitLogBehavior;
  behaviorName: string;
  path: string;
  visited: LoggerVisitedItem; // 被访问信息Id（文章Id、动态Id等）
  ip: string;
  country: string;
  region: string;
  province: string;
  city: string;
  isp: string;
  os: string;
  browser: string;
  visitDate: Date;
}

export interface LoggerVisitedItem {
  Id: string;
  title: string;
  link: string;
}
