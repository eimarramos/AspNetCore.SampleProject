import type { Pokemon } from "./Pokemon";

export type Pagination = {
  items: Pokemon[];
  pageNumber: number;
  totalPages: number;
  totalCount: number;
  hasPreviousPage: boolean;
  hasNextPage: boolean;
};
