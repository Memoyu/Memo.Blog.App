export interface OpenSourceListRequest {
  title?: string;
  description?: string;
  dateBegin?: string;
  dateEnd?: string;
}

export interface OpenSourceListItem {
  projectId: string;
  repoId?: number;
  repoFullName: string;
  title: string;
  description: string;
  imageUrl: string;
  readmeUrl: string;
  htmlUrl: string;
  star: number;
  fork: number;
  createTime: Date;
}
