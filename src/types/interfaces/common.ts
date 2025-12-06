export interface PaginationRequest {
  size: number;
  page: number;
  sort?: string;
}

export interface PaginationResult<T> {
  items: Array<T>;
  total: number;
}

export interface MetricItem {
  name: string;
  value?: number;
}
