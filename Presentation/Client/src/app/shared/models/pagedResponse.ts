export interface PagedResponse<T> {
  collection: T[];
  pageNumber: number;
  pageSize: number;
  totalPages: number;
}
