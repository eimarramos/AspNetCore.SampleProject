import type { Pokemon } from "~/domain/pokemon/model/Pokemon"
import type { PokeApiDTO } from "../types/PokeApiDTO"


export const mapPokemon = (data: PokeApiDTO): Pokemon => {
  return {
    id: data.pokedexNumber,
    name: data.name,
    height: data.height,
    weight: data.weight,
    image: data.image,
    stats: data.stats.map(stat => {
      return {
        name: stat.name,
        value: stat.value,
      }
    }),
    types: data.types,
  }
}
