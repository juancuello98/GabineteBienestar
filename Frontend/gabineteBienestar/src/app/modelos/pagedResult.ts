export declare class PaginationResult {
  totalRows: number;
  pageCount: number;
  constructor(rows: number, count: number);
}
export declare class PagedResult<T> {
  pagination: PaginationResult;
  data: T[];
  fromJson(res: any, type: new () => T): PagedResult<T>;
}
