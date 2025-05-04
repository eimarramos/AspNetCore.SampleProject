import { BASE_URL } from "~/config/config";
import type { PaginationResponse } from "../../types/PaginationResponse";

export const getPokedexResponse = async (pageNumber: number) => {
  const data = await fetch(`${BASE_URL}?PageNumber=${pageNumber}&PageSize=5`);
  const paginationResponse: PaginationResponse = await data.json();

  return paginationResponse;
};
