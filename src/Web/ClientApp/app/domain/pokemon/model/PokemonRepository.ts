import type { Pokemon } from "./Pokemon"

export type PokemonRepository = {
  getPokemons: () => Promise<Pokemon[]>
}
