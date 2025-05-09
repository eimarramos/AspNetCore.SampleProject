import type { PokeApiDTO } from "./PokeApiDTO";

export type PaginationResponse = {
  items: PokeApiDTO[];
  pageNumber: number;
  totalPages: number;
  totalCount: number;
  hasPreviousPage: boolean;
  hasNextPage: boolean;
};
