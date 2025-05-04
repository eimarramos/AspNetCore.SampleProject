import type { PokemonRepository } from "~/domain/pokemon/model/PokemonRepository";
import { getPokedexResponse } from "./getPokemon/getPokedex";
import { mapPokemon } from "../PokemonMapper/PokemonMapper";
import type { Pokemon } from "~/domain/pokemon/model/Pokemon";
import type { Pagination } from "~/domain/pokemon/model/Pagination";

const getPokedex = async (pageNumber: number) => {
  const paginationResponse = await getPokedexResponse(pageNumber);

  const pokemonsMapped: Pokemon[] = await Promise.all(
    paginationResponse.items.map(async (pokemon) => mapPokemon(pokemon))
  );

  const paginationResponseMapped: Pagination = {
    ...paginationResponse,
    items: pokemonsMapped,
  };

  return paginationResponseMapped;
};

export const pokemonApiRepository: PokemonRepository = {
  getPokedex,
};
