import type { Pagination } from "./Pagination";

export type PokemonRepository = {
  getPokedex: (pageNumber: number) => Promise<Pagination>;
};
