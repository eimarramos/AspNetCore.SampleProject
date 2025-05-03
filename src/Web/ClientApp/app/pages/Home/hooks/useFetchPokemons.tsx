import { useEffect, useState } from 'react'
import { pokemonService } from '../../../services/pokemonService/pokemonService'
import type { Pokemon } from '~/domain/pokemon/model/Pokemon'

export const useGetPokemons = (numberOfPokemons: number = 150) => {
  const [pokemons, setPokemons] = useState<Pokemon[]>([])
  const [isLoading, setIsloading] = useState<boolean>(true)
  const [error, setError] = useState<boolean>(false)

  useEffect(() => {
    const fetchData = async () => {
      try {
        const getPokemons = await pokemonService.getPokemons()

        setPokemons(getPokemons)
      } catch (error) {
        setError(true)
      } finally {
        setIsloading(false)
      }
    }

    fetchData()
  }, [numberOfPokemons])

  return { pokemons, isLoading, error }
}
