import type { PokemonRepository } from "~/domain/pokemon/model/PokemonRepository";

let pokemonRepo: PokemonRepository;

const init = (pokemonRepository: PokemonRepository) => {
  pokemonRepo = pokemonRepository;
};

const getPokedex = async (pageNumber: number) => {
  const pokemonsDetails = pokemonRepo.getPokedex(pageNumber);
  return pokemonsDetails;
};

export const pokemonService = {
  init,
  getPokedex,
};
