import type { PokemonRepository } from '~/domain/pokemon/model/PokemonRepository'
import { getPokedex } from './getPokemon/getPokedex'
import { mapPokemon } from '../PokemonMapper/PokemonMapper'
import type { Pokemon } from '~/domain/pokemon/model/Pokemon'

const getPokemons = async () => {
  const pokedex = await getPokedex()

  const pokemonsMapped : Pokemon[] = await Promise.all(
    pokedex.items.map(async (pokemon) => mapPokemon(pokemon))
  )

  return pokemonsMapped
}

export const pokemonApiRepository: PokemonRepository = {
  getPokemons,
}
