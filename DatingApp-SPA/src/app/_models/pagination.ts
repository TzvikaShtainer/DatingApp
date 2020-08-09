export interface Pagination {
    currectPage: number;
    itemPerPage: number;
    totalItems: number;
    totalPages: number;
}

// tslint:disable-next-line: no-unused-expression
export class PaginatedResult<T> {
    result: T;
    pagination: Pagination;
}
