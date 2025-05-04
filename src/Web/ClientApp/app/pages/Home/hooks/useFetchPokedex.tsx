import { useEffect, useState } from 'react'
import { pokemonService } from '~/services/pokemonService/pokemonService'
import type { Pagination } from '~/domain/pokemon/model/Pagination'

export const useGetPokedexFetch = (pageNumber: number = 1) => {
  const [pagination, setPagination] = useState<Pagination>({
    items: [],
    pageNumber: 0,
    totalPages: 0,
    totalCount: 0,
    hasPreviousPage: false,
    hasNextPage: false,
  })
  const [isLoading, setIsloading] = useState<boolean>(true)
  const [error, setError] = useState<boolean>(false)

  useEffect(() => {
    const fetchData = async () => {
      try {
        const getPagination = await pokemonService.getPokedex(pageNumber)

        setPagination(getPagination)
      } catch (error) {
        setError(true)
      } finally {
        setIsloading(false)
      }
    }

    fetchData()
  }, [pageNumber])

  return { pagination, isLoading, error }
}